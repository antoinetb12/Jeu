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
            case 0: LoaderCombat.instance.changeResolution(1280, 720); break;
            case 1:
                LoaderCombat.instance.changeResolution(1920, 1080); break;
        }
        //ControleurCombat.instance.finTour();
    }
    public void changeValueFullScreen()
    {
        LoaderCombat.instance.changeTypeFullScreen(dropdownFullScreen.value);
        
        //ControleurCombat.instance.finTour();
    }
    private void Start()
    {
        if (Screen.width == 1920)
        {
            dropdownResolution.value = 1;
        }
        else
        {
            dropdownResolution.value = 0;
        }
        switch (Screen.fullScreenMode)
        {
            case FullScreenMode.Windowed: dropdownFullScreen.value = 0; break;
            case FullScreenMode.FullScreenWindow: dropdownFullScreen.value = 1; break;
            case FullScreenMode.ExclusiveFullScreen: dropdownFullScreen.value = 2; break;

        }
    }

}
