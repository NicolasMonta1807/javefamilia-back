package com.javefamilia.gestionreservas.Mensajeria;
import com.javefamilia.gestionreservas.Model.EspacioEventType;
import jakarta.enterprise.context.ApplicationScoped;

@ApplicationScoped
public class EspacioEventHandler {

    public void handleEspacioEvent(EspacioEvent espacioEvent) {

        System.out.println("Procesando evento de espacio: " + espacioEvent.getEventType());
        if (espacioEvent.getEventType() == EspacioEventType.ESPACIO_CREATED) {
        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_UPDATED){

        } else if (espacioEvent.getEventType() == EspacioEventType.ESPACIO_DELETED) {
        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_ADDED){

        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_UPDATED){

        } else if(espacioEvent.getEventType() == EspacioEventType.ESPACIO_HORARIO_DELETED){

        }else{
            System.out.println("Evento no reconocido: " + espacioEvent.getEventType());
        }
    }
}