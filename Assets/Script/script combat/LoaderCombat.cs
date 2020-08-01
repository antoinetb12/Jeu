using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class LoaderCombat : MonoBehaviour
{
    public static LoaderCombat instance = null;
    public GameObject controleur;
    public List<GameObject> joueurs;
    // Start is called before the first frame update
    [Range(1, 4)]
    public float pixelScale = 1;
    private int pixelsPerUnit = 32;
    private float halfScreen = 0.5f;
    public int resolutionx=1280;
    public int resolutiony=720;
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
        if (ControleurCombat.instance == null)
        {
            Instantiate(controleur);
        }
    }
    public void changeResolution(int pixel,int width,int heigth)
    {
        resolutionx = width;
        resolutiony = heigth;
        PixelPerfectCamera p=GetComponentInParent<PixelPerfectCamera>();
        p.assetsPPU = pixel;
        p.refResolutionX = width;
        p.refResolutionY = heigth;
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
