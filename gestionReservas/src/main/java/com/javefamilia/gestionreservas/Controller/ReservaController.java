package com.javefamilia.gestionreservas.Controller;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.javefamilia.gestionreservas.Model.Reserva;
import com.javefamilia.gestionreservas.Service.ReservaServiceBean;
import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;


import java.util.List;

@Path("/")
public class ReservaController {

    @Inject
    ReservaServiceBean reservaServiceBean;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/reservas")
    public List<Reserva> getReservas() {
        return reservaServiceBean.loadAllTimedEntries();
    }
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/reserva/{id}")
    public Reserva getReservaById(@PathParam("id") int id) {
        return reservaServiceBean.loadReservaById(id);
    }

    @Transactional
    @POST
    @Path("/reserva")
    @Consumes(MediaType.APPLICATION_JSON)
    public void createReserva(Reserva reserva) {
        reservaServiceBean.craeteReserva(reserva);
    }

    @Transactional
    @PUT
    @Path("/reserva/{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    public void updateReserva(Reserva reserva, @PathParam("id") int id) {
        reservaServiceBean.updateReserva(reserva, id);
    }

    @Transactional
    @DELETE
    @Path("/reserva/{id}")
    public void deleteReserva(@PathParam("id") int id) {
        reservaServiceBean.deleteReserva(id);
    }
}
