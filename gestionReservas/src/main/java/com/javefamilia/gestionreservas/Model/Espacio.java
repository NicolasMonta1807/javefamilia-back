package com.javefamilia.gestionreservas.Model;

import jakarta.persistence.*;

import java.time.Duration;
import java.util.List;

@Entity
@Table(name = "espacios")
public class Espacio {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)  // Generación automática de ID
    @Column(name = "Id")
    private Long Id;

    @Column(name = "Name", nullable = false)
    private String Name;

    @Column(name = "Description", nullable = false)
    private String Description;

    @Column(name = "OpeningTime", nullable = false)
    private Duration OpeningTime;

    @Column(name = "ClosingTime", nullable = false)
    private Duration ClosingTime;

    @Column(name = "Capacity", nullable = false)
    private int Capacity;

    @Column(name = "AffiliateRate", nullable = false)
    private double AffiliateRate;

    @Column(name = "NonAffiliateRate", nullable = false)
    private double NonAffiliateRate;

    @Column(name = "BeneficiaryRate", nullable = false)
    private double BeneficiaryRate;

    @OneToMany(mappedBy = "espacio", cascade = CascadeType.ALL, fetch = FetchType.LAZY)
    private List<HorarioEspacio> Horarios;

    // Constructor
    public Espacio() {}

    // Getters y setters
    public Long getId() {
        return Id;
    }

    public void setId(Long Id) {
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

    public Duration getOpeningTime() {
        return OpeningTime;
    }

    public void setOpeningTime(Duration OpeningTime) {
        this.OpeningTime = OpeningTime;
    }

    public Duration getClosingTime() {
        return ClosingTime;
    }

    public void setClosingTime(Duration ClosingTime) {
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
