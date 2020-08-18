using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler,IEndDragHandler,IBeginDragHandler,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    public int index;
    public Item item;
    public DescriptionScript description;
    private GameObject image;
    public bool drag=false;

    // Start is called before the first frame update
    public void remove()
    {
        InventaireControlleur.instance.removeItem(item);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        if (item != null)
        {

            description.updateText(item.description);
            description.AfficheDescription();
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out vector);
            Vector3 vecto = transform.localPosition;
            description.setPosition(vecto);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("up");

            if (item != null)
            {
                description.DesafficheDescription();
            }
        
        

    }

    public void OnEndDrag(PointerEventData eventData)
    {
       //Destroy(image);
        drag = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
        Debug.Log(image.transform.position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        drag = true;
        if (item != null)
        {
            description.DesafficheDescription();
        }
        image = (GameObject) Instantiate(transform.GetChild(0).GetComponent<Image>().gameObject,transform.position,Quaternion.identity, GameObject.Find("inventaire").transform);
        image.transform.localScale = new Vector3(1f, 1f, 1f);
        image.transform.position = Input.mousePosition;
        image.transform.localPosition = transform.localPosition;
        CanvasGroup canvasGroup = image.GetComponent<CanvasGroup>();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        

    }

    public void OnDrop(PointerEventData eventData)
    {
        SlotScript slot = eventData.pointerDrag.GetComponent<SlotScript>();
        //this.item = slot.item;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
