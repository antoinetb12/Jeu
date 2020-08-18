using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingsMenu;
    public GameObject InventaireMenu;

    public void afficheInventaire()
    {
        InventaireControlleur.instance.displayInventaire();
    }
    public void afficheSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }
    public void closeInventaire()
    {
        InventaireControlleur.instance.closeInventaire();
    }
   public void closeSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }
    public void menuPrincipal()
    {
        DontDestroyOnLoadScene.instance.removeDontDestroyOnLoad();
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void save()
    {
        ControleurCombat.instance.SaveAll();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
