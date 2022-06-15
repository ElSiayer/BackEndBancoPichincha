# BackEndBancoPichincha
## Introduction
Esta aplicacion es un proyecto webapi en NETCORE 5 para exponer Apis REST.

## Entidades
El proyecto consta de cuatro tipos de entidades y estas son:
###Persona

Esta entidad consta con los siguientes atributos: nombre, genero,edad, identificación, dirección, teléfono y un id como PK.

### Cliente

Esta entidad heredad de la entidad Persona y consta con los siguientes atributos clienteid, contraseña, estado, donde clienteid es su PK

### Cuenta

Esta entidad maneja los siguientes atributos número cuenta, tipo cuenta, saldo Inicial, estado, donde número cuenta es su PK

### Movimientos

Esta entidad consta con los siguientes atributos: Fecha, tipo movimiento, valor, saldo y un id como su PK

## Architecture
El proyecto tiene configurado un DockerFile y Docker compose para que pueda ser montado en cualquier ambiente.
Para correr el proyecto se debe ingresar los siguientes comandos en la carpeta raiz del proyecto:
    
    docker build -t backendbancopichincha:latest .
    
y al finalizar este comando se debe ejecutar el comando de docker compose para que se levante el ambiente:
    
    docker-compose up
