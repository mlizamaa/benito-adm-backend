namespace Benito.Datos.Iot.Modelo
{
    public class Actuador{

        public string Codigo {get; set; }
        public string Nombre {get; set; }
        public string Descripcion {get; set; }
        public ETipoActuador Tipo {get; set; }
        public KeyValuePair<string, string>[] Pines {get; set; }

        public EEstadoActuador Estado { get; set; }
    }

    public enum EEstadoActuador{
        Encendido = 1,
        Apagado = 2
    }

    
    
}