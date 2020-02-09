using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    Controleur controleur;
    void Start()
    {
        controleur = Controleur.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sourisCamera;
        if (Input.GetMouseButtonDown(0))
        {
            sourisCamera= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Controleur.instance.click(sourisCamera);
        }
    }
}
