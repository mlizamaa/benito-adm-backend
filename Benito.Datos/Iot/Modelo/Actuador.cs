namespace Benito.Datos.Iot.Modelo
{
    public class Actuador{

        public string Codigo {get; set; }
        public string Nombre {get; set; }
        public string Descripcion {get; set; }
        public ETipoActuador Tipo {get; set; }
        public KeyValuePair<string, int>[] Pines {get; set; }

        public EEstadoActuador Estado { get; set; }
        
        public bool Encender(){

            return true;
        }

        public bool Apagar(){
            return true;
        }
    }

    public enum EEstadoActuador{
        Encendido = 1,
        Apagado = 2
    }

    
    
}