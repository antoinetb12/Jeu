using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="items/equipement",fileName = "ItemsEquipementTemplate")]
public class ItemsEquipementTemplate : ItemTemplate
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
    public AnimationClip animation;
    public override Item getItem()
    { 
        return new ItemEquipement(itemName, itemSprite, typeObjet,description, po, feu, eau, terre, vent, dommage, pdv, pm, pa, resistance, initiative,typeEquipement, animation);
    }
}
public enum TypeEquipement
{
    plastron,casque,anneau,amulette,botte,ceinture,arme,cape
}
