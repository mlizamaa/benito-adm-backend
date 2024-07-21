namespace Benito.Model.Entities.IOT{

    public class Sensor  : BenitoBaseEntity
    {
        public string? Nombre {get; set; }
        public string? Descripcion {get; set; }
        public ETipoSensor? Tipo {get; set; }
        public ETipoValor? TipoValor {get; set; }
        //public KeyValuePair<string, string>[]? Pines {get; set; }

    }

    public enum ETipoValor {

        /// <summary>
        /// Valor analogo
        /// </summary>
        /// <value></value>
        ///     
        Analogico = 1,

        /// <summary>
        /// Valor digital
        /// </summary>
        /// <value></value>
        /// 
        Digital = 2
    }
}