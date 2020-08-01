using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown dropdownResolution;
    public Dropdown dropdownFullScreen;

    public void changeValueResolution()
    {
        Debug.Log(dropdownResolution.value);
        switch (dropdownResolution.value)
        {
            case 0: LoaderCombat.instance.changeResolution(32, 1280, 720); break;
            case 1:
                LoaderCombat.instance.changeResolution(48, 1920, 1080); break;
        }
        //ControleurCombat.instance.finTour();
    }
    public void changeValueFullScreen()
    {
        Debug.Log(dropdownFullScreen.value);
        switch (dropdownFullScreen.value)
        {
            case 0: LoaderCombat.instance.changeTypeFullScreen(FullScreenMode.Windowed); break;
            case 1:
                LoaderCombat.instance.changeTypeFullScreen(FullScreenMode.FullScreenWindow); break;
            case 2:
                LoaderCombat.instance.changeTypeFullScreen(FullScreenMode.ExclusiveFullScreen); break;
        }
        //ControleurCombat.instance.finTour();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
