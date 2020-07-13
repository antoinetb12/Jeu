using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public string nom;
    public bool mur;
    private int x;
    private int y;
    private int effet;
    Color m_OriginalColor;
    Color m_MouseOverColor = Color.red;

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    Renderer m_Renderer;
    void OnMouseOver()
    {
        m_Renderer.material.color = Color.red;
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject."+ m_Renderer.material.color + "," + m_MouseOverColor);
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = m_OriginalColor;
    }
    public void changeColor()
    {
        m_Renderer.material.color = Color.yellow;
    }
    private void OnMouseUp()
    {
        ControleurCombat.instance.click(this);
    }
    public void setVariable(int x, int y, bool mur)
    {
        this.x = x;
        this.y = y;
        this.mur = mur;
    }
    public Case(int x,int y,bool mur)
    {
        this.x = x;
        this.y = y;
        this.mur = mur;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the mesh renderer component from the GameObject
        m_Renderer = this.GetComponent<Renderer>();
        //Fetch the original color of the GameObject
        m_OriginalColor = m_Renderer.material.color;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }

    public void PrintName()
    {
        print(x +", "+y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
