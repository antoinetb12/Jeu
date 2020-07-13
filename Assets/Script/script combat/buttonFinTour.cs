using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFinTour : MonoBehaviour
{
    // Start is called before the first frame update
  public void finTour()
    {
        ControleurCombat.instance.finTour();
    }
}
