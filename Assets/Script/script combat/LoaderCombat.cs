using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCombat : MonoBehaviour
{
    public GameObject controleur;
    public List<GameObject> joueurs;
    // Start is called before the first frame update
    void Start()
    {
        if (ControleurCombat.instance == null)
        {
            Instantiate(controleur);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
