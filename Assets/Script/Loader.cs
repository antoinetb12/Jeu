using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject controleur;
    // Start is called before the first frame update
    void Start()
    {
        if (Controleur.instance == null)
        {
            Instantiate(controleur);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
