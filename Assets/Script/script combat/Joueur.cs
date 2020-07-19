using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : Personnage
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void move(List<Case> chemin)
    {

        StartCoroutine(smoothMovement(chemin));
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void lanceSort(Sort s)
    {
        if (s.cout <= pa)
        {
            pa=pa - s.cout;

        }
    }
    public void recoitAttaque(int montant)
    {
        pdv = pdv - montant;
        
        if (pdv <= 0)
        {

            this.GetComponent<Renderer>().material.color=Color.red;

        }
    }

    public override void finMouvement()
    {
        //throw new System.NotImplementedException();
    }
}
