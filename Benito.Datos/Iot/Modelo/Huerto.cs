// Autor : Marcelo Lizama Araya
// Fecha : 30/09/2023


using System.Linq;

namespace Benito.Datos.Iot.Modelo {
    public class Huerto {
        /// <summary>
        /// Código del huerto
        /// </summary>
        /// <value></value>
        /// 
        public string Codigo {get; set; }

        /// <summary>
        /// Nombre del huerto
        /// </summary>
        public string Nombre {get; set; }
        public string Descripcion {get; set; }
        public Sensor[] Sensores {get; set; }
        public Actuador[] Actuadores {get; set; }

        /// <summary>
        /// Busca el actuador de riego en el arreglo de actuadores del huerto y lo enciende durante el tiempo indicado, 
        /// Si codActuador está vacío, se encienden todos los actuadores de riego al mismo tiempo
        /// </summary>
        /// <param name="segundos">Cantidad de segundos que se encenderá el riego </param>
        /// <param name="codActuador">Código del regador, si está vacío se encenderán todos los regadores</param>
        /// <returns>Bool</returns>
            public bool Regar(int segundos, string codActuador){

                var regadores = this.Actuadores.Where(actuador=> actuador.Tipo == ETipoActuador.BombaAgua)
                    .ToList();
                if(regadores.Count == 0)
                    throw new System.NotImplementedException("No se encontraron actuadores de riego en el huerto");

                // inicializa un array de temporizadores asincronos
                System.Threading.Tasks.Task[] temporizadores = new System.Threading.Tasks.Task[Actuadores.Length];
                regadores.ForEach(actuador=>  {
                    // si el codigo del actuador es vacio o es igual al codigo del actuador actual
                    if(string.IsNullOrEmpty(codActuador) || actuador.Codigo == codActuador){
                        // se enciende el actuador
                        actuador.Estado = EEstadoActuador.Encendido;
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
