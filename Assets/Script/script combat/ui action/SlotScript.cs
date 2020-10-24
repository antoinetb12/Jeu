using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    public Item item { get; set; }
    public DescriptionScript description;
    public SlotType slotType;
    private GameObject image;

    // Start is called before the first frame update
    public virtual void remove()
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
       Destroy(image);
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
        Debug.Log(image.transform.position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (item != null)
        {
            description.DesafficheDescription();
        }
        image = (GameObject) Instantiate(transform.GetChild(0).GetComponent<Image>().gameObject,transform.position,Quaternion.identity, GameObject.Find("Canvas").transform);
        image.transform.localScale = new Vector3(1f, 1f, 1f);
        image.transform.position = Input.mousePosition;
        image.transform.localPosition = transform.localPosition;
        CanvasGroup canvasGroup = image.GetComponent<CanvasGroup>();
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        

    }

   
}
public enum SlotType
{
    inventaire, Equipement
}