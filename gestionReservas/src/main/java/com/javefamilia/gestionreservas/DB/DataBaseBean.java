package com.javefamilia.gestionreservas.DB;

import java.util.List;

import com.javefamilia.gestionreservas.Model.Espacio;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.persistence.TypedQuery;
import jakarta.transaction.Transactional;

@ApplicationScoped
public class DataBaseBean {
    @PersistenceContext(unitName = "reservas")
    EntityManager em;

    @Transactional
    public void store(Object entry) {
        em.persist(entry);
    }
    public List<Espacio> loadAllTimedEntries() {
        TypedQuery<Espacio> query = em.createQuery("SELECT t from Espacio t", Espacio.class);
        List<Espacio> result = query.getResultList();
        return result;
    }
}