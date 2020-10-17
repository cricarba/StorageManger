# Storage Manager

Este proyecto en un POC para crear una libreria que se encargue de almacenar archivos en Azure o el sistema de archivos.

Para esto se uso patron estraetgia para cada uno de los sistemas de almacenamiento, esto hace que se pueda extender para agrergar mas sistemas de almacenamiento (BD, AWS, Etc)

Para resolver la estrategia se creo una fabrica que recibe un enumerado que define el tipo de almacenamiento.


La libreria expone 3 clases publicas para ser usadas por el cliente
