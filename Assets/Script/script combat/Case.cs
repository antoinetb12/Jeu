﻿using System;
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
    public int distance=0;
    public Case precedent;
    public bool visite=false;
    public int gCost; 
    public int hCost;
    Color m_OriginalColor;
    Color lastColor;
    Color m_MouseOverColor = Color.red;

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    Renderer m_Renderer;
    void OnMouseOver()
    {
        ControleurCombat.instance.hover(this);
        
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Mouse is over GameObject."+ m_Renderer.material.color + "," + m_MouseOverColor);
    }
    public void changeRed()
    {
        m_Renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        m_Renderer.material.color = lastColor;
        ControleurCombat.instance.exitCase(this);
       
    }
    public void exit()
    {
        m_Renderer.material.color = lastColor;
    }
    public void initColor()
    {
        m_Renderer.material.color = m_OriginalColor;
        lastColor = m_OriginalColor;

    }
    public void changeColor()
    {
        initRenderer();
        lastColor = Color.yellow;
        m_Renderer.material.color = Color.yellow;
    }
    private void OnMouseUp()
    {
        ControleurCombat.instance.click(this);
    }
    public void setVariable(int x, int y)
    {
        this.x = x;
        this.y = y;
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
        initRenderer();
        //Fetch the mesh renderer component from the GameObject


    }
    private void initRenderer()
    {
        if (m_Renderer == null)
        {
            m_Renderer = this.GetComponent<Renderer>();
            m_OriginalColor = m_Renderer.material.color;
            lastColor = m_OriginalColor;
        }
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