using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controleur : MonoBehaviour
{
    public static Controleur instance=null;
    private Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text=GameObject.Find("Text").GetComponent<Text>();
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    public void click(Ray ray)
    {
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            text.text=hit.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
