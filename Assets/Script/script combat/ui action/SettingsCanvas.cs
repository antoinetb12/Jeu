using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingsMenu;

    public void afficheSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
   public void closeSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
