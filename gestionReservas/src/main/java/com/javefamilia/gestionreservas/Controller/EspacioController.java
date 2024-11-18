package com.javefamilia.gestionreservas.Controller;

import com.javefamilia.gestionreservas.Model.Espacio;
import com.javefamilia.gestionreservas.Service.EspacioServiceBean;
import jakarta.inject.Inject;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;

import java.util.List;

@Path("/espacio")
public class EspacioController {
    @Inject
    EspacioServiceBean espacioServiceBean;

    @GET
    @Produces(MediaType.APPLICATION_JSON)  // Esto indica que la respuesta será en JSON
    @Path("/")
    public List<Espacio> getEspacio() {
        return espacioServiceBean.loadAllTimedEntries();
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/{id}")
    public Espacio getEspacioById(@PathParam("id") String id) {
        return espacioServiceBean.loadEspacioById(id);
    }
}
