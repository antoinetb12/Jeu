using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotSortScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sort sort { get; set; }
    public DescriptionScript description;
    private GameObject image;
    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;
    public float durationThreshold = 1.0f;
    // Start is called before the first frame update
    public virtual void remove()
    {
        InventaireControlleur.instance.removeItem(null);
    }

    private void Update()
    {
        if (isPointerDown && !longPressTriggered && sort != null)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
                longPress();
            }
        }
    }
    private void longPress()
    {
        description.updateText(sort.description);
        description.AfficheDescription();
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out vector);
        Vector3 vecto = transform.localPosition;
        description.setPosition(vecto);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        timePressStarted = Time.time;
        /* if (sort != null)
         {

             description.updateText(sort.description);
             description.AfficheDescription();
             //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out vector);
             Vector3 vecto = transform.localPosition;
             description.setPosition(vecto);
         }*/
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        Debug.Log("up");
        if (sort != null)
        {
            if (longPressTriggered)
            {
                description.DesafficheDescription();
                longPressTriggered = false;

            }
            else
            {
                ControleurCombat.instance.selectionneSort(sort);
            }

           
        }
    }



}
