using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effet : MonoBehaviour
{
    public StyleEffect styleEffect;
    public TimeEffect timeEffect;
    public int duree;
    public GameObject image;
    private int tourInstancie = 0;
    private GameObject instanceImage;
    private Case c;
    private Personnage lanceur;
    private Personnage victime;
    public int TourInstancie { get => tourInstancie; set => tourInstancie = value; }
    public Personnage Lanceur { get => lanceur; set => lanceur = value; }
    public Personnage Victime { get => victime; set => victime = value; }
    public Case C { get => c; set => c = value; }
    public GameObject InstanceImage { get => instanceImage; set => instanceImage = value; }

    public abstract void applyEffect();
    public abstract void applyEffect(Personnage victime);
    public abstract void cancelEffect();

    public abstract void cancelEffect(Personnage victime);

    public abstract void copy(Effet e);
    public abstract void addComponent(GameObject g);
}
public enum StyleEffect
{
    Case, Personnage
}
public enum TimeEffect
{
    Debut,Fin
}