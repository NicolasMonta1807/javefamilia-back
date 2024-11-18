package com.javefamilia.gestionreservas.Service;

import com.javefamilia.gestionreservas.Model.Espacio;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.persistence.TypedQuery;
import jakarta.transaction.Transactional;

import java.util.List;

@ApplicationScoped
public class EspacioServiceBean {
    @PersistenceContext(unitName = "reservas")
    EntityManager em;

    public List<Espacio> loadAllTimedEntries() {
        TypedQuery<Espacio> query = em.createQuery("SELECT e from Espacio e", Espacio.class);
        List<Espacio> result = query.getResultList();
        return result;
    }

    public Espacio loadEspacioById(String id) {
        return em.find(Espacio.class, id);
    }
}