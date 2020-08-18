using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ItemTemplate : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public TypeObjet typeObjet;
    public string description;

    public abstract Item getItem();
}
public enum TypeObjet
{
    Utilitaire,Equipement,Quete
}
