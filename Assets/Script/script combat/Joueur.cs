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
    public bool lanceSort(Sort s)
    {
        if (s.cout <= pa)
        {
            pa= pa - s.cout;
            return true;

        }
        return false;
    }
    public override void recoitAttaque(Sort s)
    {
        base.recoitAttaque(s);
        pdv = pdv - s.pdd;
        
        if (pdv <= 0)
        {

            this.GetComponent<Renderer>().material.color=Color.red;

        }
    }

    public override void finMouvement()
    {
        Debug.Log("fin position " + transform.position.x + ", " + transform.position.y);
        //throw new System.NotImplementedException();
    }

    public override int getStatusPersonnage()
    {
        return 0;
    }
}
