using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public static DontDestroyOnLoadScene instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        foreach (GameObject g in objects)
        {
            DontDestroyOnLoad(g);
        }
    }
    public void removeDontDestroyOnLoad()
    {
        
            foreach (var element in objects)
            {
                SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
            }
        
    }
    public GameObject[] objects;

    // Update is called once per frame
    void Update()
    {
        
    }
}
