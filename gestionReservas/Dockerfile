# Maven build
FROM maven:latest AS build
WORKDIR /app

COPY pom.xml .
RUN mvn dependency:go-offline -B

COPY src ./src

RUN mvn clean package -DskipTests

# Wildfly container
FROM quay.io/wildfly/wildfly:33.0.1.Final-jdk17

ENV WILDFLY_HOME /opt/jboss/wildfly
ENV MYSQL_DRIVER_VERSION 9.1.10
ENV MYSQL_JAR_NAME mysql-connector-j-${MYSQL_DRIVER_VERSION}.jar
ENV MYSQL_MODULE_NAME com.mysql

ENV DB_HOST db-host
ENV DB_NAME db-name
ENV DB_USER db-user
ENV DB_PASSWORD db-password

WORKDIR $WILDFLY_HOME

RUN mkdir -p $WILDFLY_HOME/modules/system/layers/base/com/mysql/main
COPY ./config/module.xml $WILDFLY_HOME/modules/system/layers/base/com/mysql/main/
COPY ./config/mysql-connector-j-9.1.0.jar $WILDFLY_HOME/modules/system/layers/base/com/mysql/main

COPY ./config/standalone.xml $WILDFLY_HOME/standalone/configuration

RUN $WILDFLY_HOME/bin/add-user.sh javefamilia javefamilia --silent

COPY --from=build /app/target/gestionReservas.gestionReservas.war $WILDFLY_HOME/standalone/deployments/

user jboss

EXPOSE 8083
EXPOSE 9993

CMD ["/opt/jboss/wildfly/bin/standalone.sh", "-b", "0.0.0.0"]
