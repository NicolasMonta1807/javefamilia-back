# JaveFamilia - Backend

## Despliegue en Entorno de Desarrollo

Este proyecto utiliza `docker-compose` y `Docker Swarm` para el despliegue en un entorno de desarrollo. Sigue los pasos a continuación para levantar los servicios:

### Instrucciones

1. **Esquema del Despliegue de Desarrollo:**
   ![Diagrama de despliegue](https://github.com/NicolasMonta1807/javefamilia-back/blob/main/Docs/Deploy.jpg?raw=true)

2. **Construcción de las Imágenes:**
   Ejecuta el siguiente script en la raíz del proyecto para construir todas las imágenes necesarias:
   ```bash
   ./docker-build.sh
   ```

3. **Configurar Docker Swarm:**
   - Inicializa el Swarm en el nodo principal (manager):
     ```bash
     docker swarm init
     ```
   - Si tienes nodos adicionales que deseas unir al Swarm como workers, ejecuta el siguiente comando en cada uno de ellos (el token y la dirección se proporcionan al ejecutar `docker swarm init` en el manager):
     ```bash
     docker swarm join --token <TOKEN> <MANAGER-IP>:<PORT>
     ```

4. **Desplegar los Servicios en el Swarm:**
   - Despliega los servicios utilizando el siguiente comando:
     ```bash
     docker stack deploy -c docker-compose-prod.yml javefamilia-stack
     ```

5. **Acceso a la Documentación Swagger:**
   - Una vez que los contenedores estén corriendo, accede a la documentación de todos los endpoints a través del API Gateway en:
     ```
     http://localhost:5050/swagger
     ```
   - Aquí encontrarás la documentación Swagger que agrupa todos los endpoints de los microservicios.

