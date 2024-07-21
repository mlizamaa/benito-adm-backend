# Benito.Api

Apis para el sistema benito

- __ECommerce__
- __Inventario__
- __IOT__


## solución de problemas

__Publicar la aplicación en docker__

1. Especificar el puerto en el que quedará servida la Api al ejecutar el comando dotnet run, por ejemplo para usar el puerto 5001:

```
 "Urls": "http://localhost:5001",
```

2. Crear dockerfile
Para hecer el dockerfile mas liviano se publicará la carpeta ./bin/Release/net7.0/publish
Para el ejemplo el directorio base es Benito.Api y se utiliza el puerto 5001

```
#  imagen docker con .net 7.0
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ./bin/Release/net7.0/publish .

# habilita el puerto 5001
EXPOSE 5001
EXPOSE 443
RUN set ASPNETCORE_ENVIRONMENT=Staging
ENTRYPOINT ["dotnet", "Benito.Api.dll"]
```

3. Compilar la imagen del contenedor especificando un nombre y una versión, en  este ejemplo se utiliza el nombre benito.api y la version v1.0.0

```
$ docker build . -t benito.api:v1.0.0 
```

4. Ejecutar la Imágen para servir la api mediante el contenedor docker enlazado a la red del host (esta máquina)

```
$ docker run benito.api:v1.0.0 --network host
```

5. Configurar NGINX para exponer el sitio desde la imagen de contendor docker




