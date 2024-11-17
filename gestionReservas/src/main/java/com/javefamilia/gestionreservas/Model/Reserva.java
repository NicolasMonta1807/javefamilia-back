package com.javefamilia.gestionreservas.Model;

import com.javefamilia.gestionreservas.Model.Enum.EstadoPago;
import jakarta.persistence.*;
import java.time.LocalDate;

@Entity
@Table(name = "reserva")
public class Reserva {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Id")
    private Integer Id;

    @Column(name = "UsuarioId")
    private String UsuarioId;

    @Column(name = "EspacioId")
    private String EspacioId;

    @Column(name = "HorarioId")
    private String HorarioId;

    @Column(name = "FechaAgendamiento")
    private LocalDate FechaAgendamiento;

    @Column(name = "FechaReserva")
    private LocalDate FechaReserva;

    @Enumerated(EnumType.STRING)
    @Column(name = "EstadoPago")
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
