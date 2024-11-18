docker build -t nicolasmonta1807/api-gateway:latest ./ApiGateway
docker build -t nicolasmonta1807/auth-service:latest ./AuthService
docker build -t nicolasmonta1807/espacios-service:latest ./EspacioService
docker build -t nicolasmonta1807/sedes-service:latest ./SedesService

docker push nicolasmonta1807/api-gateway
docker push nicolasmonta1807/auth-service
docker push nicolasmonta1807/espacios-service
docker push nicolasmonta1807/sedes-service
