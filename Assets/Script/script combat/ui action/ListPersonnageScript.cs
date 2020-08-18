using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPersonnageScript : MonoBehaviour
{
    public List<ContainerPerso> containerPersos;

    public void setJoueur(List<Personnage> perso)
    {
        for(int i = 0; i < perso.Count; i++)
        {
            containerPersos[i].gameObject.SetActive(true);
            containerPersos[i].setJoueur(perso[i]);
        }
    }
    public void clear()
    {
        foreach(ContainerPerso containerPerso in containerPersos)
        {
            containerPerso.gameObject.SetActive(false);
        }
    }
}
