using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventaireScript : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    public void OnDrop(PointerEventData eventData)
    {
        SlotScript slot = eventData.pointerDrag.GetComponent<SlotScript>();
        if ( slot==null ||slot.slotType != SlotType.Equipement)
        {
            return;
        }
        slot.remove();
    }
}
