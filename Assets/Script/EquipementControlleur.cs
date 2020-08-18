using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementControlleur : MonoBehaviour
{
    public EquipementScript footEquipement;
    public EquipementScript plastronEquipement;
    public EquipementScript casqueEquipement;
    public EquipementScript capeEquipement;


    public void Equip(ItemEquipement i)
    {
        EquipementScript equipementScript= GetEquipementScript(i.typeEquipement);
        equipementScript.equip(i);
    }
    public void Desequipe(ItemEquipement i)
    {
        EquipementScript equipementScript = GetEquipementScript(i.typeEquipement);
        equipementScript.Desequip();
    }
    public EquipementScript GetEquipementScript(TypeEquipement type)
    {
        switch (type)
        {
            case TypeEquipement.botte: return footEquipement;
            case TypeEquipement.plastron: return plastronEquipement;
            case TypeEquipement.casque:return casqueEquipement;
            case TypeEquipement.cape:return capeEquipement;
        }
        return null;

    }
}
