package com.javefamilia.gestionreservas.DB;

import java.util.List;

import com.javefamilia.gestionreservas.Model.Espacio;
import jakarta.inject.Inject;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;

@Path("/")
public class RootResource {

    @Inject
    DataBaseBean dbBean;

    @GET
    @Path("/db")
    @Produces(MediaType.TEXT_PLAIN)
    public String getDatabaseEntries() {
        List<Espacio> entries = dbBean.loadAllTimedEntries();
        StringBuffer sb = new StringBuffer();
        for (Espacio t : entries) {
            sb.append(t);
            sb.append("\n");
        }
        return sb.toString();
    }
}