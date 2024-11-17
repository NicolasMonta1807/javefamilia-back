package com.javefamilia.gestionreservas.Model;

import java.io.Serializable;
import java.time.Duration;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import com.javefamilia.gestionreservas.Mensajeria.DurationDeserializer;
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
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @JsonProperty("Id")  // Mapea explícitamente "Id" del JSON al atributo "id" en Java
    private String id;

    @JsonProperty("Availavility")
    private boolean availability;

    @JsonProperty("StartTime")
    @JsonDeserialize(using = DurationDeserializer.class)
    private Duration startTime;

    @JsonProperty("EndTime")
    @JsonDeserialize(using = DurationDeserializer.class)
    private Duration endTime;

    @ManyToOne
    @JoinColumn(name = "Id") // Este "Id" debe hacer referencia a la columna en la base de datos
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

    public Duration getStartTime() {
        return startTime;
    }

    public void setStartTime(Duration startTime) {
        this.startTime = startTime;
    }

    public Duration getEndTime() {
        return endTime;
    }

    public void setEndTime(Duration endTime) {
        this.endTime = endTime;
    }

    public Espacio getEspacio() {
        return espacio;
    }

    public void setEspacio(Espacio espacio) {
        this.espacio = espacio;
    }
}
