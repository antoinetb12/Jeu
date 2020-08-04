﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effet : MonoBehaviour
{
    public StyleEffect styleEffect;
    public TimeEffect timeEffect;
    public int duree;
    public GameObject image;
    private int tourInstancie = 0;


    private Personnage lanceur;
    private Personnage victime;
    public int TourInstancie { get => tourInstancie; set => tourInstancie = value; }
    public Personnage Lanceur { get => lanceur; set => lanceur = value; }
    public Personnage Victime { get => victime; set => victime = value; }

    public abstract void applyEffect();
    public abstract void applyEffect(Personnage victime);
    protected Effet(StyleEffect styleEffect, TimeEffect timeEffect, int duree,GameObject image)
    {
        this.styleEffect = styleEffect;
        this.timeEffect = timeEffect;
        this.duree = duree;
        this.image = image;
    }

    public abstract Effet copy();
}
public enum StyleEffect
{
    Case, Personnage
}
public enum TimeEffect
{
    Debut,Fin
}