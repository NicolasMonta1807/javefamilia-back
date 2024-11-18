package com.javefamilia.gestionreservas.Service;

import com.javefamilia.gestionreservas.Model.Espacio;
import com.javefamilia.gestionreservas.Model.Reserva;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.persistence.TypedQuery;
import jakarta.transaction.Transactional;

import java.util.List;

public class ReservaServiceBean {

    @PersistenceContext(unitName = "reservas")
    EntityManager em;

    public List<Reserva> loadAllTimedEntries() {
        TypedQuery<Reserva> query = em.createQuery("SELECT r from Reserva r", Reserva.class);
        List<Reserva> result = query.getResultList();
        return result;
    }
    public Reserva loadReservaById(int id) {
        return em.find(Reserva.class, id);
    }
    //Tal vez verificar que exista el espacio que se va a reservar
    public void craeteReserva(Reserva reserva) {
        em.persist(reserva);
    }
    public void updateReserva(Reserva reserva, int id) {
        Reserva reservaToUpdate = em.find(Reserva.class, id);
        reservaToUpdate.setUsuarioId(reserva.getUsuarioId());
        reservaToUpdate.setEspacioId(reserva.getEspacioId());
        reservaToUpdate.setHorarioId(reserva.getHorarioId());
        reservaToUpdate.setFechaAgendamiento(reserva.getFechaAgendamiento());
        reservaToUpdate.setFechaReserva(reserva.getFechaReserva());
        reservaToUpdate.setEstadoPago(reserva.getEstadoPago());
        em.merge(reservaToUpdate);
    }
    public void deleteReserva(int id) {
        Reserva reserva = em.find(Reserva.class, id);
        em.remove(reserva);
    }
}
