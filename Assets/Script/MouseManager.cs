using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    Controleur controleur;
    private Vector3 position;
    void Start()
    {
        controleur = Controleur.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            Controleur.instance.click(position);
        }
    }
}
