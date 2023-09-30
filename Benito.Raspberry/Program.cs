using Benito.Datos.Iot.Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Device.Gpio;
using Benito.Raspberry.Huerto;
using System;


var huerto = new Huerto();
huerto.Actuadores = new Actuador[]{
    new Actuador(){
        Codigo = "B1",
        Nombre = "Bomba 1",
        Descripcion = "Bomba de agua 1",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("B1", 18)
        }
    },
    new Actuador(){
        Codigo = "B2",
        Nombre = "Bomba 2",
        Descripcion = "Bomba de agua 2",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("B2", 23)
        }
    },
    new Actuador(){
        Codigo = "B3",
        Nombre = "Bomba 3",
        Descripcion = "Bomba de agua 3",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("B3", 24)
        }
    },

};
var huertoRasperry = new HuertoRaspberry(huerto);


var riego = huertoRasperry.RegarAsync(5, "B1");
Console.WriteLine("Regando...");
riego.Wait();
Console.WriteLine("Riego terminado");



