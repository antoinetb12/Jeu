using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropdownResolution : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown dropdown;
  public void changeValue()
    {
        Debug.Log(dropdown.value);
        switch (dropdown.value)
        {
            case 0: LoaderCombat.instance.changeResolution(32, 1280, 720);break;
            case 1:
                LoaderCombat.instance.changeResolution(48, 1920, 1080);break;
        }
        //ControleurCombat.instance.finTour();
    }

    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }
}
