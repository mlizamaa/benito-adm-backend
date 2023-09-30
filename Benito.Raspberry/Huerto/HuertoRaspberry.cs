using System.Device.Gpio;
using System.Threading.Tasks;
using Benito.Datos.Iot.Modelo;
namespace Benito.Raspberry.Huerto
{
    public class HuertoRaspberry
    {
        private GpioController _gpioController;
        private Benito.Datos.Iot.Modelo.Huerto _huerto;
       // private Benito.Datos _huerto;
        public HuertoRaspberry(Benito.Datos.Iot.Modelo.Huerto huerto)
        {
            _gpioController = new GpioController();
            _huerto = new Benito.Datos.Iot.Modelo.Huerto();

        }

        public async Task<bool> RegarAsync(int segundos, string codActuador)
        {
            var regadores = this._huerto.Actuadores.Where(actuador=> actuador.Tipo == ETipoActuador.BombaAgua)
                    .ToList();
                if(regadores.Count == 0)
                    throw new System.NotImplementedException("No se encontraron actuadores de riego en el huerto");

                // inicializa un array de temporizadores asincronos
                System.Threading.Tasks.Task[] temporizadores = new System.Threading.Tasks.Task[this._huerto.Actuadores.Length];
                regadores.ForEach(actuador=>  {
                    // si el codigo del actuador es vacio o es igual al codigo del actuador actual
                    if(string.IsNullOrEmpty(codActuador) || actuador.Codigo == codActuador){
                        // se enciende el actuador
                        actuador.Estado = EEstadoActuador.Encendido;
                        
                        // se enciende el pin del actuador
                        _gpioController.Write(actuador.Pines[0].Value, PinValue.High);
                        

                        // se crea un temporizador asincrono
                        temporizadores[regadores.IndexOf(actuador)] = System.Threading.Tasks.Task.Run(async () => {
                            // se espera la cantidad de segundos indicados
                            await System.Threading.Tasks.Task.Delay(segundos * 1000);
                            // se apaga el actuador
                            actuador.Estado = EEstadoActuador.Apagado;
                        });
                    }
                });

                // se espera a que todos los temporizadores terminen
                System.Threading.Tasks.Task.WaitAll(temporizadores);

                // valida que todos los actuadores esten apagados
                if(regadores.Any(actuador=> actuador.Estado == EEstadoActuador.Encendido))
                    return false;
                
                return true;
            
        }
    }
}