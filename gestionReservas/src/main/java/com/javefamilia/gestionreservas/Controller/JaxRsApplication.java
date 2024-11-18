package com.javefamilia.gestionreservas.Controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.json.JsonMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import jakarta.ws.rs.ApplicationPath;
import jakarta.ws.rs.core.Application;

@ApplicationPath("/reservas")
public class JaxRsApplication extends Application {
    public JaxRsApplication() {
        ObjectMapper om = new ObjectMapper();
        om.registerModule(new JavaTimeModule());
    }
}