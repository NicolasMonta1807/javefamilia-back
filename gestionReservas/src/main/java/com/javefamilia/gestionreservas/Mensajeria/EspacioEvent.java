package com.javefamilia.gestionreservas.Mensajeria;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import com.javefamilia.gestionreservas.Model.EspacioEventType;
import com.javefamilia.gestionreservas.Model.HorarioEspacio;

import java.time.Duration;
import java.util.List;

public class EspacioEvent {

    @JsonProperty("eventType")
    private EspacioEventType EventType;

    @JsonProperty("Id")
    private String Id;

    @JsonProperty("Name")
    private String Name;

    @JsonProperty("Description")
    private String Description;

    @JsonProperty("OpeningTime")
    @JsonDeserialize(using = DurationDeserializer.class)
    private Duration OpeningTime;

    @JsonProperty("ClosingTime")
    @JsonDeserialize(using = DurationDeserializer.class)
    private Duration ClosingTime;

    @JsonProperty("Capacity")
    private int Capacity;

    @JsonProperty("AffiliateRate")
    private double AffiliateRate;

    @JsonProperty("NonAffiliateRate")
    private double NonAffiliateRate;

    @JsonProperty("BeneficiaryRate")
    private double BeneficiaryRate;

    @JsonProperty("Horarios")
    private List<HorarioEspacio> Horarios;

    // Constructor con todos los parámetros
    public EspacioEvent(EspacioEventType eventType, String id, String name, String description,
                        Duration openingTime, Duration closingTime, int capacity, double affiliateRate,
                        double nonAffiliateRate, double beneficiaryRate, List<HorarioEspacio> horarios) {
        EventType = eventType;
        Id = id;
        Name = name;
        Description = description;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        Capacity = capacity;
        AffiliateRate = affiliateRate;
        NonAffiliateRate = nonAffiliateRate;
        BeneficiaryRate = beneficiaryRate;
        Horarios = horarios;
    }

    // Constructor con solo eventType e id
    public EspacioEvent(EspacioEventType eventType, String id) {
        EventType = eventType;
        Id = id;
    }

    public EspacioEvent() {
    }

    // Getters y Setters
    public EspacioEventType getEventType() {
        return EventType;
    }

    public void setEventType(EspacioEventType eventType) {
        this.EventType = eventType;
    }

    public String getId() {
        return Id;
    }

    public void setId(String id) {
        this.Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        this.Name = name;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        this.Description = description;
    }

    public Duration getOpeningTime() {
        return OpeningTime;
    }

    public void setOpeningTime(Duration openingTime) {
        this.OpeningTime = openingTime;
    }

    public Duration getClosingTime() {
        return ClosingTime;
    }

    public void setClosingTime(Duration closingTime) {
        this.ClosingTime = closingTime;
    }

    public int getCapacity() {
        return Capacity;
    }

    public void setCapacity(int capacity) {
        this.Capacity = capacity;
    }

    public double getAffiliateRate() {
        return AffiliateRate;
    }

    public void setAffiliateRate(double affiliateRate) {
        this.AffiliateRate = affiliateRate;
    }

    public double getNonAffiliateRate() {
        return NonAffiliateRate;
    }

    public void setNonAffiliateRate(double nonAffiliateRate) {
        this.NonAffiliateRate = nonAffiliateRate;
    }

    public double getBeneficiaryRate() {
        return BeneficiaryRate;
    }

    public void setBeneficiaryRate(double beneficiaryRate) {
        this.BeneficiaryRate = beneficiaryRate;
    }

    public List<HorarioEspacio> getHorarios() {
        return Horarios;
    }

    public void setHorarios(List<HorarioEspacio> horarios) {
        this.Horarios = horarios;
    }
}
