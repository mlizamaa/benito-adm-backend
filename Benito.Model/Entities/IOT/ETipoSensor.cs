// Enum TipoSensor para sensores de arduino
namespace Benito.Model.Entities.IOT{
    public enum ETipoSensor{
        
        // Sensor de temperatura y humedad de baja precision
        Dht11 = 1,
        /// <summary>
        /// Sensor de temperatura y humedad de alta precision
        /// </summary>
        Dht22 = 2,
        /// <summary>
        /// Sensor de temperatura de baja precision 
        /// </summary>
        Lm35 = 3,
        /// <summary>
        /// Sensor de distancia ultrasonico  HC-SR04
        /// </summary>
        HcSr04 = 4,
        /// <summary>
        /// | Sensor de gas | MQ2 |
        /// </summary>
        Mq2 = 5,
        /// <summary>
        /// | Sensor de gas | MQ3 |
        /// </summary>
        Mq3 = 6,
        /// <summary>
        /// | Sensor de gas | MQ4 |
        /// </summary>
        Mq4 = 7,
        // | Sensor de gas | MQ5 |
        Mq5 = 8,
        /// <summary>
        /// | Sensor de gas | MQ6 |
        /// </summary>
        Mq6 = 9,
        /// <summary>
        /// | Sensor de gas | MQ7 |
        /// </summary>
        Mq7 = 10,
        /// <summary>
        /// | Sensor de gas | MQ8 |
        /// </summary>
        Mq8 = 11,

        /// <summary>
        /// | Sensor de gas | MQ9 |
        /// </summary>
        Mq9 = 12,
        /// <summary>
        /// | Sensor de gas | MQ135 |
        /// </summary>
        Mq135 = 13,
        /// <summary>
        /// | Sensor de gas | MQ136 |
        /// </summary>
        Mq136 = 14,
        /// <summary>
        /// | Sensor de gas | MQ137 |
        /// </summary>
        Mq137 = 15,
        /// <summary>
        /// | Sensor de gas | MQ138 |
        /// </summary>
        Mq138 = 16,
        /// <summary>
        /// | Sensor de gas | MQ214 |
        /// </summary>
        Mq214 = 17,
        /// <summary>
        /// | Sensor de gas | MQ216 |
        /// </summary>
        Mq216 = 18,
        /// <summary>
        /// | Sensor de gas | MQ303A |
        /// </summary>
        /// <value></value>
        Mq303A = 19,

        /// <summary>
        /// | Sensor de gas | MQ306A |
        /// </summary>
        Mq306A = 20,
        /// <summary>
        /// | Sensor de gas | MQ307A |
        /// </summary>
        Mq307A = 21,
        /// <summary>
        /// | Sensor de gas | MQ309A |
        /// </summary>
        /// <value></value>
        /// 
        Mq309A = 22,
        /// <summary>
        /// | Sensor de gas | MQ310A |
        /// </summary>
        /// <value></value>
        ///     
        Mq310A = 23,
        /// <summary>
        /// | Sensor de gas | MQ311A |
        /// </summary>
        ///     

        Mq311A = 24,
        /// <summary>
        ///     | Sensor de gas | MQ312A |
        ///     </summary>
        ///
        Mq312A = 25,
        /// <summary>
        ///    | Sensor de gas | MQ313A |
        ///    </summary>
        ///    
        Mq313A = 26,
        /// <summary>
        ///   | Sensor de gas | MQ314A |
        ///   </summary>
        ///   
        Mq314A = 27,
        /// <summary>
        /// | Sensor de gas | MQ315A |
        /// </summary>
    /// <summary>
        /// Sensor de temperatura 
        /// </summary>
        /// <value></value>
        /// 
        SensorTemperatura = 20,

        Mq316A = 29,
        // otro tipo de sensor, no de gas
        /// <summary>
        /// Sensor de distancia infrarrojo GP2Y0A21YK0F
        /// </summary>
        /// 
        Gp2Y0A21YK0F = 30,
        /// <summary>
        /// Sensor de distancia ultrasonico  HC-SR04
        /// </summary>
        ///
        HcSr04_2 = 31,
        
        /// <summary>
        /// Sensor de movimiento PIR
        /// </summary>
        /// 
        Pir = 32,
        /// <summary>
        /// Sensor de movimiento PIR HC-SR501
        /// </summary>
        /// 
        HcSr501 = 33
    }
}