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
            new KeyValuePair<string, int>("B1", 1)
        }
    }
};
var huertoRasperry = new HuertoRaspberry(huerto);

huerto.Actuadores.ToList().ForEach(actuador=> Console.WriteLine($"Actuador {actuador.Nombre} estado {actuador.Estado}"));   
var riego = huertoRasperry.RegarAsync(5, "B1");
huerto.Actuadores.ToList().ForEach(actuador=> Console.WriteLine($"Actuador {actuador.Nombre} estado {actuador.Estado}"));   
System.Threading.Tasks.Task.WaitAll(riego);
huerto.Actuadores.ToList().ForEach(actuador=> Console.WriteLine($"Actuador {actuador.Nombre} estado {actuador.Estado}"));


