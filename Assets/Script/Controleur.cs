using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controleur : MonoBehaviour
{
    public static Controleur instance=null;
    private Text text;
    private BoardManager boardManager;
    private Joueur joueur;
    bool deplacement;
    // Start is called before the first frame update
    void Start()
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
    public void setDeplacement(bool deplacement)
    {
        this.deplacement = deplacement;
    }
    public void click(Vector3 position)
    {
        RaycastHit2D hit= Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider != null)
        {

           hit.collider.gameObject.GetComponent<Lieu>().PrintName();
           // print("au click : " + hit.collider.gameObject.GetComponent<Lieu>().getCenterPosition());
          // joueur.move(hit.collider.gameObject.GetComponent<Lieu>().getCenterPosition());
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void initGame()
    {
        boardManager.boardSetup();
        joueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Joueur>();
    }
    public void finDeplacement()
    {
       // print("fin");
    }
}
