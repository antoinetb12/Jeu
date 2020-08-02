using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPrincipal : MonoBehaviour
{
    public string loadScene;
    // Start is called before the first frame update
    public void start()
    {
        SceneManager.LoadScene(loadScene);
    }
    public void quitter()
    {
        Application.Quit();
    }
}
