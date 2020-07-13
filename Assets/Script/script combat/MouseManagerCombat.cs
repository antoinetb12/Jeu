using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManagerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    ControleurCombat controleur;
    private Vector3 position;
    void Start()
    {
        controleur = ControleurCombat.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // ControleurCombat.instance.click(position);
        }
    }
}
