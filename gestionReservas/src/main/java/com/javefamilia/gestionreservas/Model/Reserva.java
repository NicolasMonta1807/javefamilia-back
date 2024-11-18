package com.javefamilia.gestionreservas.Model;

import com.javefamilia.gestionreservas.Model.Enum.EstadoPago;
import jakarta.persistence.*;

import java.io.Serializable;
import java.time.LocalDate;

@Entity
@NamedQuery(name = "Reserva.findAll", query = "SELECT r FROM Reserva r")
@Table(name = "reserva")
public class Reserva implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer Id;

    private String UsuarioId;

    private String EspacioId;

    private String HorarioId;

    private LocalDate FechaAgendamiento;

    private LocalDate FechaReserva;

    @Enumerated(EnumType.STRING)
    private EstadoPago EstadoPago;

    // Getters y Setters
    public Integer getId() {
        return Id;
    }

    public void setId(Integer Id) {
        this.Id = Id;
    }

    public String getUsuarioId() {
        return UsuarioId;
    }

    public void setUsuarioId(String UsuarioId) {
        this.UsuarioId = UsuarioId;
    }

    public String getEspacioId() {
        return EspacioId;
    }

    public void setEspacioId(String EspacioId) {
        this.EspacioId = EspacioId;
    }

    public String getHorarioId() {
        return HorarioId;
    }

    public void setHorarioId(String HorarioId) {
        this.HorarioId = HorarioId;
    }

    public LocalDate getFechaAgendamiento() {
        return FechaAgendamiento;
    }

    public void setFechaAgendamiento(LocalDate FechaAgendamiento) {
        this.FechaAgendamiento = FechaAgendamiento;
    }

    public LocalDate getFechaReserva() {
        return FechaReserva;
    }

    public void setFechaReserva(LocalDate FechaReserva) {
        this.FechaReserva = FechaReserva;
    }

    public EstadoPago getEstadoPago() {
        return EstadoPago;
    }

    public void setEstadoPago(EstadoPago EstadoPago) {
        this.EstadoPago = EstadoPago;
    }
}
