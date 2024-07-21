# bash script para publicar la api y compilar la imagen docker en el repositorio local
!#/bin/bash

# Variables
DOCKER_IMAGE_NAME="benito.api"
DOCKER_IMAGE_VERSION="v1.0.0"
DOCKER_IMAGE_TAG="$DOCKER_IMAGE_NAME:$DOCKER_IMAGE_VERSION"

#imprimir en consola


# Eliminar la imagen docker si existe
echo "Eliminando la imagen docker si existe"
docker rm -f $DOCKER_IMAGE_NAME

# publicar la api en modo release sin imprimir en consola
echo "Publicando la api en modo release"
dotnet publish -c Release -v q
# Compilar la imagen docker sin imprimir en consola
echo "Compilando la imagen docker"
docker build -t $DOCKER_IMAGE_TAG -f Dockerfile . >> /dev/null

# ejecutar la imagen docker sin imprimir en consola
echo "Ejecutando la imagen docker"
docker run -d --name $DOCKER_IMAGE_NAME --network host $DOCKER_IMAGE_TAG

# validar el estado de la imagen docker
echo "Validando el estado de la imagen docker"
docker ps -a | grep $DOCKER_IMAGE_NAME

# valida la configuracion nginx
echo "Validando la configuracion nginx"

nginx -t







