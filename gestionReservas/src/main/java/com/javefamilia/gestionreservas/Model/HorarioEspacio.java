package com.javefamilia.gestionreservas.Model;

import java.io.Serializable;
import java.sql.Time;
import java.time.Duration;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import com.javefamilia.gestionreservas.Mapper.TimeDeserializer;
import jakarta.persistence.*;

/**
 * The persistent class for the horarioEspacio database table.
 *
 */
@Entity
@NamedQuery(name="HorarioEspacio.findAll", query="SELECT h FROM HorarioEspacio h")
public class HorarioEspacio implements Serializable {
    private static final long serialVersionUID = 1L;
    @Id
    @JsonProperty("Id")  // Mapea explícitamente "Id" del JSON al atributo "id" en Java
    private String id;

    @JsonProperty("Availavility")
    private boolean availability;

    @JsonProperty("StartTime")
    @JsonDeserialize(using = TimeDeserializer.class)
    private Time startTime;

    @JsonProperty("EndTime")
    @JsonDeserialize(using = TimeDeserializer.class)
    private Time endTime;

    @ManyToOne
    @JoinColumn(name = "Id_espacio")
    private Espacio espacio;

    // Getters y Setters

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public boolean isAvailability() {
        return availability;
    }

    public void setAvailability(boolean availability) {
        this.availability = availability;
    }

    public Time getStartTime() {
        return startTime;
    }

    public void setStartTime(Time startTime) {
        this.startTime = startTime;
    }

    public Time getEndTime() {
        return endTime;
    }

    public void setEndTime(Time endTime) {
        this.endTime = endTime;
    }

    public Espacio getEspacio() {
        return espacio;
    }

    public void setEspacio(Espacio espacio) {
        this.espacio = espacio;
    }

}
