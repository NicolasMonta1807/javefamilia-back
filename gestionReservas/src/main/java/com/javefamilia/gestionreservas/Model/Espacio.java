package com.javefamilia.gestionreservas.Model;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import java.io.Serializable;
import java.sql.Time;
import java.util.List;

@Entity
@NamedQuery(name = "Espacio.findAll", query = "SELECT e FROM Espacio e")
@Table(name = "espacios")
public class Espacio implements Serializable {
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

    // New field to store the SedeId
    private String SedeId;

    @OneToMany(mappedBy = "espacio", cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    @JsonManagedReference
    private List<HorarioEspacio> Horarios;

    // Constructor
    public Espacio(String Id, String Name, String Description, Time OpeningTime, Time ClosingTime, int Capacity,
            double AffiliateRate, double NonAffiliateRate, double BeneficiaryRate, List<HorarioEspacio> Horarios,
            String SedeId) {
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
        this.SedeId = SedeId;
    }

    public Espacio() {
    }

    // Getters and setters
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

    public Time getOpeningTime() {
        return OpeningTime;
    }

    public void setOpeningTime(Time openingTime) {
        this.OpeningTime = openingTime;
    }

    public Time getClosingTime() {
        return ClosingTime;
    }

    public void setClosingTime(Time closingTime) {
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

    public String getSedeId() {
        return SedeId;
    }

    public void setSedeId(String sedeId) {
        this.SedeId = sedeId;
    }
}
