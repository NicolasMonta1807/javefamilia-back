package com.javefamilia.gestionreservas.Model;

import jakarta.persistence.*;
import java.io.Serializable;

import java.sql.Time;
import java.util.List;

@Entity
@NamedQuery(name = "Espacio.findAll", query = "SELECT e FROM Espacio e")
public class Espacio implements Serializable{
    private static final long serialVersionUID = 1L;
    @Id
    private String Id;

    private String Name;

    private String Description;

    private Time OpeningTime;

    private Time ClosingTime;

    private int Capacity;

    private double AffiliateRate;

    private double NonAffiliateRate;

    private double BeneficiaryRate;

    @OneToMany(mappedBy = "espacio", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<HorarioEspacio> Horarios;

    // Constructor
    public Espacio(String Id, String Name, String Description, Time OpeningTime,
                   Time ClosingTime, int Capacity, double AffiliateRate,
                   double NonAffiliateRate, double BeneficiaryRate, List<HorarioEspacio> Horarios) {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.OpeningTime = OpeningTime;
        this.ClosingTime = ClosingTime;
        this.Capacity = Capacity;
        this.AffiliateRate = AffiliateRate;
        this.NonAffiliateRate = NonAffiliateRate;
        this.BeneficiaryRate = BeneficiaryRate;
        this.Horarios = Horarios;
    }
    public Espacio() {}
    // Getters y setters
    public String getId() {
        return Id;
    }

    public void setId(String id) {
        this.Id = Id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String Name) {
        this.Name = Name;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String Description) {
        this.Description = Description;
    }

    public Time getOpeningTime() {
        return OpeningTime;
    }

    public void setOpeningTime(Time OpeningTime) {
        this.OpeningTime = OpeningTime;
    }

    public Time getClosingTime() {
        return ClosingTime;
    }

    public void setClosingTime(Time ClosingTime) {
        this.ClosingTime = ClosingTime;
    }

    public int getCapacity() {
        return Capacity;
    }

    public void setCapacity(int Capacity) {
        this.Capacity = Capacity;
    }

    public double getAffiliateRate() {
        return AffiliateRate;
    }

    public void setAffiliateRate(double AffiliateRate) {
        this.AffiliateRate = AffiliateRate;
    }

    public double getNonAffiliateRate() {
        return NonAffiliateRate;
    }

    public void setNonAffiliateRate(double NonAffiliateRate) {
        this.NonAffiliateRate = NonAffiliateRate;
    }

    public double getBeneficiaryRate() {
        return BeneficiaryRate;
    }

    public void setBeneficiaryRate(double BeneficiaryRate) {
        this.BeneficiaryRate = BeneficiaryRate;
    }

    public List<HorarioEspacio> getHorarios() {
        return Horarios;
    }

    public void setHorarios(List<HorarioEspacio> Horarios) {
        this.Horarios = Horarios;
    }
}
