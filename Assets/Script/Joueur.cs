﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : Personnage
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void move(Vector3 end)
    {

        StartCoroutine(smoothMovement(end));
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
