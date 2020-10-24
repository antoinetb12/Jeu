using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipementSlotControlleur : MonoBehaviour
{
    public static EquipementSlotControlleur instance = null;
    public SlotEquipementScript bottes;
    public GameObject JoueurDisplay;
    public cameraRenderFollow cameraa;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Display(List<ItemEquipement> items, Personnage p, EquipementControlleur equipementControlleur)
    {
        DisplayItemsSlot(bottes, TypeEquipement.botte, items, equipementControlleur);
        cameraa.personnageToFollow = p;
    }
    public void DisplayItemsSlot(SlotEquipementScript equipement, TypeEquipement type, List<ItemEquipement> items, EquipementControlleur equipementControlleur)
    {
        Image image;
        ItemEquipement item = null;
        Debug.Log(items.Count);
        equipement.equipementControlleur = equipementControlleur;
        equipement.typeEquipement = type;
        if ((item = containsTypeItem(type, items)) != null)
        { 
            equipement.item = item;
            
            image = equipement.transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(1, 1, 1, 1);
            image.sprite = item.itemSprite;
        }
        else
        {
            equipement.item = null;
            image = equipement.transform.GetChild(0).GetComponent<Image>();
            Color color = image.color;
            color.a = 0;
            image.color = color;
            image.sprite = null;
        }
    }

    public ItemEquipement containsTypeItem(TypeEquipement type, List<ItemEquipement> list)
    {
        return list.Find(item => item.typeEquipement == type);
    }
}
