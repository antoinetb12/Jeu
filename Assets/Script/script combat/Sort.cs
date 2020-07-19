using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : MonoBehaviour
{
    public string nom;
    public int pdd = 1;
    public int range = 1;
    public int cout = 3;
    // Start is called before the first frame update
    void OnMouseUp()
    {

        ControleurCombat.instance.selectionneSort(this);
    }
}
