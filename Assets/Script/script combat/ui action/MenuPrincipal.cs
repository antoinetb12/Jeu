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
        ChangeSceneService.instance.ChangeScene(loadScene);
    }
    public void nouvellePartie()
    {
        ChangeSceneService.instance.ChangeScene(loadScene,"nouvelle partie");
    }
    public void quitter()
    {
        Application.Quit();
    }
}
