package com.javefamilia.gestionreservas.Mensajeria;
import com.javefamilia.gestionreservas.Model.Espacio;
import com.javefamilia.gestionreservas.Model.Enum.EspacioEventType;
import jakarta.ejb.Stateless;
import jakarta.persistence.EntityManager;
import jakarta.persistence.PersistenceContext;
import jakarta.persistence.PersistenceContextType;
import jakarta.transaction.Transactional;

@Stateless
public class EspacioEventHandler {
    @PersistenceContext(unitName = "reservas", type = PersistenceContextType.TRANSACTION)
    EntityManager em;
    @Transactional
    public void handleEspacioEvent(EspacioEvent espacioEvent) {
        System.out.println("Procesando evento de espacio: " + espacioEvent.getEventType());

        if (espacioEvent.getEventType() == EspacioEventType.ESPACIO_CREATED) {
            Espacio espacioNuevo = new Espacio(espacioEvent.getId(), espacioEvent.getName(), espacioEvent.getDescription(),
                    espacioEvent.getOpeningTime(), espacioEvent.getClosingTime(), espacioEvent.getCapacity(), espacioEvent.getAffiliateRate(),
                    espacioEvent.getNonAffiliateRate(), espacioEvent.getBeneficiaryRate(), espacioEvent.getHorarios());
            for(int i=0;i<espacioNuevo.getHorarios().size();i++){
                espacioNuevo.getHorarios().get(i).setEspacio(espacioNuevo);
            }
            em.persist(espacioNuevo);
        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_UPDATED){
            Espacio espacio = em.find(Espacio.class, espacioEvent.getId());
            espacio.setName(espacioEvent.getName());
            espacio.setDescription(espacioEvent.getDescription());
            espacio.setOpeningTime(espacioEvent.getOpeningTime());
            espacio.setClosingTime(espacioEvent.getClosingTime());
            espacio.setCapacity(espacioEvent.getCapacity());
            espacio.setAffiliateRate(espacioEvent.getAffiliateRate());
            espacio.setNonAffiliateRate(espacioEvent.getNonAffiliateRate());
            espacio.setBeneficiaryRate(espacioEvent.getBeneficiaryRate());
            espacio.setHorarios(espacioEvent.getHorarios());
            for(int i=0;i<espacio.getHorarios().size();i++){
                espacio.getHorarios().get(i).setEspacio(espacio);
            }
            em.merge(espacio);

        } else if (espacioEvent.getEventType() == EspacioEventType.ESPACIO_DELETED) {
            Espacio espacio = em.find(Espacio.class, espacioEvent.getId());
            em.remove(espacio);
        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_ADDED){

        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_UPDATED){

        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_DELETED){

        }else{
            System.out.println("Evento no reconocido: " + espacioEvent.getEventType());
        }
    }
}