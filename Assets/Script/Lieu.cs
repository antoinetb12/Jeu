using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieu : MonoBehaviour
{
    public string nom;
    public Vector3 centerPositionBase;
    public Vector3 centerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setCenterPosition(Vector3 v)
    {
        centerPosition = v;
    }
    public Vector3 getCenterPosition()
    {
        return centerPosition;
    }
    public void PrintName()
    {
        print(nom);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
