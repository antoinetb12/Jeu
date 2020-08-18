using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LoaderCombat : MonoBehaviour
{
    public static LoaderCombat instance = null;
    // Start is called before the first frame 
    private Camera _camera;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        setResolutionPixel(Screen.width, Screen.height);

    }
    public void changeResolution(int width,int heigth)
    {
        Screen.SetResolution(width, heigth, Screen.fullScreenMode);
       /* PlayerPrefs.SetInt("resolutionX", width);
        PlayerPrefs.SetInt("resolutionY", heigth);*/
        setResolutionPixel(width, heigth);
    }
    public void setResolutionPixel(int width,int heigth)
    {

        PixelPerfectCamera p = GetComponentInParent<PixelPerfectCamera>();
        switch (width)
        {
            case 1920: p.assetsPPU = 48;
                break;
            case 1280:
                p.assetsPPU = 32;
                break;
            default: p.assetsPPU = 32;break;
        }
        p.refResolutionX = width;
        p.refResolutionY = heigth;

    }
    public void changeTypeFullScreen(int fullScreenMode)
    {
        switch (fullScreenMode)
        {

        
         case 0: Screen.fullScreenMode=FullScreenMode.Windowed; break;
        case 1:
                Screen.fullScreenMode=FullScreenMode.FullScreenWindow; break;
        case 2:
                Screen.fullScreenMode=FullScreenMode.ExclusiveFullScreen; break;
        }
        //PlayerPrefs.SetInt("fullScreen", fullScreenMode);

    }
    // Update is called once per frame
    void Update()
    {
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
            _camera.orthographic = true;
        }
        if (Screen.height > 800)
        {
          //  _camera.orthographicSize = Screen.height * ((halfScreen / pixelsPerUnit) / pixelScale);

        }
        else
        {
           // _camera.orthographicSize = Screen.height * ((halfScreen / pixelsPerUnit) / 1);

        }
    }
}
