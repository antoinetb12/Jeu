using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPleinEcran : MonoBehaviour
{
    // Start is called before the first frame update
  public void pleinEcran()
    {
        
        Debug.Log("fullscreen : " + Screen.fullScreen);
        if (Screen.fullScreen == true)
        {
            Screen.SetResolution(LoaderCombat.instance.resolutionx, LoaderCombat.instance.resolutiony, false);
        }
        else if (Screen.fullScreen == false)
        {
            Screen.SetResolution(LoaderCombat.instance.resolutionx, LoaderCombat.instance.resolutiony, true);
        }

    }
}
