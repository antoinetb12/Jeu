using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controleur : MonoBehaviour
{
    public static Controleur instance=null;
    private Text text;
    private BoardManager boardManager;
    // Start is called before the first frame update
    void Awake()
    {
       // text=GameObject.Find("Text").GetComponent<Text>();
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        boardManager = GetComponent<BoardManager>();
        initGame();
        
    }
    public void click(Ray ray)
    {
        print(ray); 
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
    void initGame()
    {
        boardManager.boardSetup();

    }
}
