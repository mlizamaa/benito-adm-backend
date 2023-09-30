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

                return true;


            }

    } 
}
