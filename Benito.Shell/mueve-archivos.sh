## script para mover archivos de un directorio a otro

# Variables
# directorio de origen
!#/bin/bash

origen=~/Dowloads

# crea una careta para cada tipo de archivo y luego mueve cada archivo a su carpeta Pdf, Office,  Tar, Zip, Imagenes, Videos, Musica, Otros

mkdir -p $origen/Pdf $origen/Office $origen/Tar $origen/Zip $origen/Imagenes $origen/Videos $origen/Musica $origen/Otros

mv $origen/*.pdf $origen/Pdf
mv $origen/*.docx $origen/Office
mv $origen/*.tar $origen/Tar
mv $origen/*.zip $origen/Zip
mv $origen/*.jpg $origen/Imagenes
mv $origen/*.png $origen/Imagenes
mv $origen/*.mp4 $origen/Videos
mv $origen/*.mp3 $origen/Musica
mv $origen/*.* $origen/Otros
