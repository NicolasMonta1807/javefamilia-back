# JaveFamilia - Backend

## Despliegue en Entorno de Desarrollo

Este proyecto utiliza `docker-compose` para el despliegue en un entorno de desarrollo. Sigue los pasos a continuación para levantar los servicios:

### Instrucciones

1. **Esquema del Despliegue de Desarrollo:**
   ![Diagrama de despliegue](https://github.com/NicolasMonta1807/javefamilia-back/blob/main/Docs/Deploy.jpg?raw=true)

2. **Ejecutar los contenedores en la raíz del proyecto:**
   ```bash
   docker compose up -d --build
   ```
    * **Para usuarios de Windows:** Ejecuta el comando equivalente en tu terminal de Docker para Windows (por ejemplo, en PowerShell o CMD).

3. **Acceso a la Documentación Swagger:**
    - Una vez que los contenedores estén corriendo, accede a la documentación de todos los endpoints a través del API Gateway en:
      ```
      http://localhost:5050/swagger
      ```
    - Aquí encontrarás la documentación Swagger que agrupa todos los endpoints de los microservicios.
4. **Instrucciones instalación de WildFly y Kafka:**

   > **Nota:** Los archivos específicos para las configuraciones de WildFly estarán en la carpeta del repositorio `Archivos configuración`.

   Para la ejecución del microservicio de reservas, es necesario tener WildFly 33.0.1.Final instalado.

   1. Dentro de la carpeta `wildfly-33.0.1.DatosReservas\standalone\configuration`, coloca el archivo `standalone.xml` especificado.
      
      * Este archivo configura el puerto para entrar a la consola en el `8083` y escucha solicitudes a través del `9993`.

      Adicionalmente, coloca el archivo `enable-reactive-messaging.cli` en la carpeta `wildfly-33.0.1.DatosReservas\bin`.

      * Una vez hecho esto, inicia el contenedor desde la consola con el archivo `.\standalone.sh` en la carpeta `wildfly-33.0.1.DatosReservas\bin`.
        
      * Abre otra consola, navega a la carpeta `wildfly-33.0.1.DatosReservas\bin` y ejecuta el siguiente comando:

        ```bash
        .\jboss-cli.sh --connect --controller=localhost:9993 --file=enable-reactive-messaging.cli
        ```

      * Apaga el contenedor (CTRL + C).

   2. Ahora necesitamos tener Kafka y Zookeeper corriendo. Esto se puede hacer con los siguientes comandos:

      ```bash
      bin\windows\zookeeper-server-start.sh config\zookeeper.properties
      bin\windows\kafka-server-start.sh config/server.properties
      ```

   3. Ahora se va a desplegar la aplicación de `gestionReservas`.  
      Para ello, inicia una vez más el contenedor.

      * Ve a través de la terminal al proyecto y en la carpeta raíz ejecuta:

        ```bash
        mvn clean package wildfly:deploy
        ```

      Si no sale ningún error, ya debería estar desplegada la aplicación en WildFly.

   En caso de preguntas, puedes referirte a este enlace:  
   [https://github.com/wildfly/quickstart/tree/33.0.1.Final/microprofile-reactive-messaging-kafka](https://github.com/wildfly/quickstart/tree/33.0.1.Final/microprofile-reactive-messaging-kafka)


