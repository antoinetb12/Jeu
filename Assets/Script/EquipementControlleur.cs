using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipementControlleur : MonoBehaviour
{
    public EquipementScript footEquipement;
    public EquipementScript plastronEquipement;
    public EquipementScript casqueEquipement;
    public EquipementScript capeEquipement;
    private Personnage j;
    private void Awake()
    {
        j = GetComponent<Personnage>();
    }

    public void Equip(ItemEquipement i)
    {
        EquipementScript equipementScript= GetEquipementScript(i.typeEquipement);
        j.addItem(i);
        equipementScript.equip(i);
    }
    public void Desequipe(ItemEquipement i)
    {
        EquipementScript equipementScript = GetEquipementScript(i.typeEquipement);
        equipementScript.Desequip();
        j.removeItem(i);
        InventaireControlleur.instance.addItem(i);
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
