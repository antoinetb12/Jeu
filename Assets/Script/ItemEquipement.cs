using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemEquipement : Item
{
    public int po;
    public int feu;
    public int eau;
    public int terre;
    public int vent;
    public int dommage;
    public int pdv;
    public int pm;
    public int pa;
    public int resistance;
    public int initiative;
    public TypeEquipement typeEquipement;
    [System.NonSerialized()]
    public AnimationClip animation;
    [System.NonSerialized()]
    public Sprite itemSpriteOnPerso;

    public ItemEquipement(string itemName, Sprite itemSprite, TypeObjet typeObjet,string description, int po, int feu, int eau, int terre, int vent, int dommage, int pdv, int pm, int pa, int resistance, int initiative, TypeEquipement typeEquipement, AnimationClip animation,Sprite itemSpriteOnPerso) : base(itemName, itemSprite, typeObjet, description)
    {
        if (typeObjet != TypeObjet.Equipement)
        {
            throw new System.Exception("l'item generer est un equipement mais le type object est pas bon");
        }
        this.po = po;
        this.feu = feu;
        this.eau = eau;
        this.terre = terre;
        this.vent = vent;
        this.dommage = dommage;
        this.pdv = pdv;
        this.pm = pm;
        this.pa = pa;
        this.resistance = resistance;
        this.initiative = initiative;
        this.typeEquipement = typeEquipement;
        this.animation = animation;
        this.itemSpriteOnPerso = itemSpriteOnPerso;
    }

    public override bool Equals(object obj)
    {
        return obj is ItemEquipement equipement &&
               po == equipement.po &&
               feu == equipement.feu &&
               eau == equipement.eau &&
               terre == equipement.terre &&
               vent == equipement.vent &&
               dommage == equipement.dommage &&
               pdv == equipement.pdv &&
               pm == equipement.pm &&
               pa == equipement.pa &&
               resistance == equipement.resistance &&
               initiative == equipement.initiative && base.Equals(obj);

    }

    public override int GetHashCode()
    {
        var hashCode = -2079438821;
        hashCode = hashCode * -1521134295 + base.GetHashCode();
        hashCode = hashCode * -1521134295 + po.GetHashCode();
        hashCode = hashCode * -1521134295 + feu.GetHashCode();
        hashCode = hashCode * -1521134295 + eau.GetHashCode();
        hashCode = hashCode * -1521134295 + terre.GetHashCode();
        hashCode = hashCode * -1521134295 + vent.GetHashCode();
        hashCode = hashCode * -1521134295 + dommage.GetHashCode();
        hashCode = hashCode * -1521134295 + pdv.GetHashCode();
        hashCode = hashCode * -1521134295 + pm.GetHashCode();
        hashCode = hashCode * -1521134295 + pa.GetHashCode();
        hashCode = hashCode * -1521134295 + resistance.GetHashCode();
        hashCode = hashCode * -1521134295 + initiative.GetHashCode();
        return hashCode;
    }

    public override void toString()
    {
        Debug.Log("" + itemName + ", " + nombreStock);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
