using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContainerPerso : MonoBehaviour
{
    [System.NonSerializedAttribute]
    public Personnage joueur;
    public Text nom;
    // Start is called before the first frame update
    public void DisplayEquipementPerso()
    {
        Debug.Log("display inv de " + joueur);
    }
    public void setJoueur(Personnage j)
    {
        joueur = j;
        nom.text = j.nom;

    }
}
