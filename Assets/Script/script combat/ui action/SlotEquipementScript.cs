using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotEquipementScript : SlotScript ,IPointerEnterHandler,IPointerExitHandler,IDropHandler
{
    public TypeEquipement typeEquipement;
    public EquipementControlleur equipementControlleur { get; set; }
    void Start()
    {

    }

    // Start is called before the first frame update
    public override void remove()
    {
        if (this.item != null)
        {
            equipementControlleur.Desequipe((ItemEquipement)item);

            this.item = null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(this.name);
        SlotScript slot = eventData.pointerDrag.GetComponent<SlotScript>();
        if (slot.item.typeObjet != TypeObjet.Equipement || ((ItemEquipement)slot.item).typeEquipement != typeEquipement)
        {
            Debug.Log("pas le bon type");
            return;
        }
        if (this.item != null)
        {
            equipementControlleur.Desequipe((ItemEquipement)item);
        }
        Debug.Log(slot);
        slot.item.toString();
        Debug.Log(equipementControlleur);
        equipementControlleur.Equip((ItemEquipement)slot.item);
        this.item = slot.item;
        slot.remove();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

}
