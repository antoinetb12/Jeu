using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : Personnage
{
    // Start is called before the first frame update
    void Start()
    {
        equipementControlleur = GetComponent<EquipementControlleur>();
        loadPlayer();
    }
    public void move(List<Case> chemin)
    {

        StartCoroutine(smoothMovement(chemin));

    }

    public void equipItem(ItemEquipement item)
    {
        equipementControlleur.Equip(item);
    }
    public void retireItem(ItemEquipement item)
    {
        equipementControlleur.Desequipe(item);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void recoitAttaque(int degat)
    {

        base.recoitAttaque(degat);
        pdv = pdv - degat;
        
        if (pdv <= 0)
        {

            this.GetComponent<Renderer>().material.color=Color.red;
            ControleurCombat.instance.meurt();

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
