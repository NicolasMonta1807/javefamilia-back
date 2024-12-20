package com.javefamilia.gestionreservas.Controller;

import jakarta.enterprise.context.ApplicationScoped;
import com.javefamilia.gestionreservas.Model.Reserva;
import com.javefamilia.gestionreservas.Service.ReservaServiceBean;
import jakarta.inject.Inject;
import jakarta.transaction.Transactional;
import jakarta.annotation.security.RolesAllowed;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import org.eclipse.microprofile.jwt.JsonWebToken;

import java.util.List;

@Path("/")
@ApplicationScoped
public class ReservaController {
    @Inject
    JsonWebToken jwt;
    @Inject
    ReservaServiceBean reservaServiceBean;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/reservas")
    // @RolesAllowed({ "Afiliado", "NoAfiliado", "Administrador", "Operario" })
    public List<Reserva> getReservas() {
        System.out.println(jwt.getClaim("role"));
        return reservaServiceBean.loadAllTimedEntries();
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("/reservas/{id}")
    // @RolesAllowed({ "Afiliado", "NoAfiliado", "Administrador", "Operario" })
    public Reserva getReservaById(@PathParam("id") int id) {
        return reservaServiceBean.loadReservaById(id);
    }

    @Transactional
    @POST
    @Path("/reservas")
    @Consumes(MediaType.APPLICATION_JSON)
    // @RolesAllowed({ "Afiliado", "NoAfiliado", "Administrador", "Operario" })
    public void createReserva(Reserva reserva) {
        String userId = jwt.getClaim("sub");
        reserva.setUsuarioId(userId);
        reservaServiceBean.craeteReserva(reserva);
    }

    @Transactional
    @PUT
    @Path("/reservas/{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    // @RolesAllowed({ "Afiliado", "NoAfiliado", "Administrador", "Operario" })
    public void updateReserva(Reserva reserva, @PathParam("id") int id) {
        reservaServiceBean.updateReserva(reserva, id);
    }

    @Transactional
    @DELETE
    @Path("/reservas/{id}")
    // @RolesAllowed({ "Afiliado", "NoAfiliado", "Administrador", "Operario" })
    public void deleteReserva(@PathParam("id") int id) {
        reservaServiceBean.deleteReserva(id);
    }
}
