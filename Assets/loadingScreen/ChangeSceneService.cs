using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeSceneService : MonoBehaviour
{
    public static ChangeSceneService instance = null;
    public Slider slider;
    AsyncOperation loadingOperation;
    AsyncOperation unLoadingOperation;
    public Canvas canvas;
    private bool isfinChargement=false;
    public string parameter = null;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (loadingOperation!=null && unLoadingOperation!=null)
        {
            float progressValue = Mathf.Clamp01((loadingOperation.progress+ unLoadingOperation.progress)/2 / 0.9f);
            slider.value = Mathf.Round(progressValue * 100);
        }else if (loadingOperation != null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            slider.value = Mathf.Round(progressValue * 100);
        }
        

    }
    public void ChangeScene(string nomScene,string parameter=null)
    {
        this.parameter = parameter;
        this.isfinChargement = false;
        canvas.gameObject.SetActive(true);
        loadingOperation = SceneManager.LoadSceneAsync(nomScene);

    }
   
    public void ChangeSceneWithUnload(string nomSceneUnload,string nomNouvelleScene)
    {
        this.isfinChargement = false;
        canvas.gameObject.SetActive(true);
        unLoadingOperation=SceneManager.UnloadSceneAsync(nomSceneUnload);
        loadingOperation = SceneManager.LoadSceneAsync(nomNouvelleScene);


    }
    public void finChargement()
    {
        this.isfinChargement = true;
        this.canvas.gameObject.SetActive(false);
        
    }
}
