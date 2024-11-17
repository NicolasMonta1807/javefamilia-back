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


