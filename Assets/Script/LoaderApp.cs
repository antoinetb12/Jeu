using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetResolution()
    {
        PlayerPrefs.GetInt("resolutionX");
        PlayerPrefs.GetInt("resolutionY");
        PlayerPrefs.GetInt("fullScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
