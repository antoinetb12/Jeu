using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleurCombat : MonoBehaviour
{
    public static ControleurCombat instance =null;
    private Text text;
    private BoardManagerCombat boardManager;
    public List<GameObject> joueurs;
    private List<GameObject> joueursIntanciate=new List<GameObject>();
    private GameObject joueur;
    private Joueur joueurc;
    bool deplacement = false;
    private int indexJoueur;
    // Start is called before the first frame update
    void Start()
    {

        
        print(instance);
       // text=GameObject.Find("Text").GetComponent<Text>();
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        boardManager = GetComponent<BoardManagerCombat>();
        initGame();
        
    }

    public void setDeplacement(bool deplacement)
    {
        this.deplacement = deplacement;
    }
    public void click(Vector3 position)
    {
        RaycastHit2D hit= Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider != null && !deplacement)
        {
            deplacement = true;
           //hit.collider.gameObject.GetComponent<Case>().PrintName();
           // print("au click : " + hit.collider.gameObject.GetComponent<Lieu>().getCenterPosition());
           Case cas= (Case)hit.collider.gameObject.GetComponent<Case>();
            //  print(cas);
            joueurc.move(new Vector3(cas.getY(), cas.getX(), 0f));
        }

        
    }
    public void click(Case c)
    {
        if (!deplacement)
        {
            deplacement = true;
            joueurc.move(new Vector3(c.getY(), c.getX(), 0f));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void initGame()
    {
        Joueur j;
        foreach(GameObject g in joueurs)
        {
            print(g);
            GameObject nobj = (GameObject)GameObject.Instantiate(g);
            joueursIntanciate.Add(nobj);
            j = nobj.GetComponent<Joueur>();
            nobj.SetActive(true);
        }
        indexJoueur = 0;
        joueur = joueursIntanciate[indexJoueur];
        joueurc = joueur.GetComponent<Joueur>();


        boardManager.boardSetup();
        //joueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Joueur>();
    }
    public void finDeplacement()
    {
        deplacement = false;
    }
    public void finTour()
    {
        indexJoueur++;
        if (indexJoueur == 4)
        {
            indexJoueur = 0;
        }
        joueur = joueursIntanciate[indexJoueur];
        joueurc = joueur.GetComponent<Joueur>();
        debutTour();

    }
    public void debutTour()
    {
        Vector3 posJoueur = joueurc.transform.position;
        boardManager.caseDeplacement(posJoueur, 1);
    }
}
