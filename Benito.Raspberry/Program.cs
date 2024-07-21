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
        Codigo = "1",
        Nombre = "BOMBA DE AGUA 1",
        Descripcion = "Bomba de agua 1",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("SIGNAL", 18)
        }
    },
    new Actuador(){
        Codigo = "2",
        Nombre = "BOMBA DE AGUA 2",
        Descripcion = "Bomba de agua 2",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("SIGNAL", 23)
        }
    },
    new Actuador(){
        Codigo = "3",
        Nombre = "BOMBA DE AGUA 3",
        Descripcion = "Bomba de agua 3",
        Estado = EEstadoActuador.Apagado,
        Tipo = ETipoActuador.BombaAgua,
        Pines = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("SIGNAL", 24)
        }
    },

};
var huertoRasperry = new HuertoRaspberry(huerto);


while(true){
    
    Console.WriteLine("Listado de actuadores");
    huerto.Actuadores.ToList().ForEach(a => {
        Console.WriteLine($"| CODIGO - Nombre: {a.Nombre} - Descripcion: {a.Descripcion} - Estado: {a.Estado}");
        Console.WriteLine($"Codigo: {a.Codigo} - Nombre: {a.Nombre} - Descripcion: {a.Descripcion} - Estado: {a.Estado}");
    });

    Console.WriteLine("Ingrese el codigo del actuador a encender, * para ractivar todos los regadores o vacio para salir");
    var codigo = Console.ReadLine();

    var codigosPermitidos = huerto.Actuadores.Select(a => int.Parse(a.Codigo)).ToList();
    int c = 0;
    var esEntero = int.TryParse(codigo, out c);
    
    if(!esEntero){
        Console.WriteLine("Ingerese un codigo valido");
        continue;
    }
    else if(!codigosPermitidos.Contains(int.Parse(codigo)))
        continue;

    Console.WriteLine("Tiempo de riego en segundos");
    var segundos = Console.ReadLine();
    
    if(string.IsNullOrEmpty(codigo))
        break;
    else if(codigo == "*"){
        var riego = huertoRasperry.RegarAsync(int.Parse(segundos), string.Empty);
        Console.WriteLine("Regando...");
        riego.Wait();
    }
    else { 
        var riego = huertoRasperry.RegarAsync(int.Parse(segundos), codigo);
        Console.WriteLine("Regando...");
        riego.Wait();
        Console.WriteLine("Riego terminado");
    }
}



