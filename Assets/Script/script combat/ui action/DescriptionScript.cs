using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionScript : MonoBehaviour
{
    public Text text;
    
    public void AfficheDescription()
    {
        gameObject.SetActive(true);
    }
    public void DesafficheDescription()
    {
        gameObject.SetActive(false);
    }
    public void updateText(string text)
    {
        this.text.text = text;
    }
    public void setPosition(Vector2 pos)
    {
        transform.localPosition = pos;
    }
}
