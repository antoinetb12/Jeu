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
    public List<GameObject> ennemies;
    private List<GameObject> joueursIntanciate=new List<GameObject>();
    private List<Joueur> joueursCIntanciate = new List<Joueur>();
    private List<GameObject> ennemisInstanciate = new List<GameObject>();
    private GameObject joueur;
    private Joueur joueurc;
    private Ennemi ennemic;
    public List<TextAsset> listMap;
    private GestionAffichageSort gestionAffichageSort;
    bool quiLeTour=true;
    bool deplacement = false;
    bool choisiSort = false;
    private Sort sortSelectionne;
    private int indexJoueur;
    List<Position> positionDeplacable;
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
        boardManager = GetComponent<BoardManagerCombat>();
        gestionAffichageSort = new GestionAffichageSort();
        initGame();
        
    }

    public void setDeplacement(bool deplacement)
    {
        this.deplacement = deplacement;
    }
    public void selectionneSort(Sort s)
    {
        if (sortSelectionne.nom == s.nom)
        {
            choisiSort = false;
        }
        else
        {
            choisiSort = true;
            sortSelectionne = s;
        }
    }
    public void click(Case c)
    {
        if (!deplacement)
        {

            if (choisiSort)
            {
                joueurc.lanceSort(sortSelectionne);
            }
            else
            {
                if (boardManager.contient(positionDeplacable, c.getX(), c.getY()))
                {
                    exitCase(c);
                    deplacement = true;
                    // Debug.Log(boardManager.grid[c.getY(), c.getX()].distance);
                    joueurc.setPm(joueurc.getPm() - boardManager.grid[c.getY(), c.getX()].distance);
                    List<Case> chemin = new List<Case>();
                    creerChemin(c, chemin);
                    chemin.Reverse();
                    joueurc.move(chemin);

                }
            }
            
        }
    }
    public void creerChemin(Case c, List<Case> cases)
    {
        if (c.precedent != null)
        {
            cases.Add(c);
            creerChemin(c.precedent, cases);
        }

    }
    
    public void affiche(List<Position> posPossible)
    {
        
        foreach (Position pos in posPossible)
        {
            Debug.Log(pos.posX + ", " + pos.posY);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void initGame()
    {
        foreach(GameObject g in joueurs)
        {
            print(g);
            GameObject nobj = (GameObject)GameObject.Instantiate(g);
            joueursIntanciate.Add(nobj);
            joueursCIntanciate.Add(nobj.GetComponent<Joueur>());
            nobj.SetActive(true);
        }
        indexJoueur = 0;
        joueur = joueursIntanciate[indexJoueur];
        joueurc = joueursCIntanciate[indexJoueur];
        initEnnemies();

        boardManager.afficheMap(listMap[0]);

        debutTour();

        //joueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Joueur>();
    }
    public void initEnnemies()
    {

        GameObject nobj = (GameObject)GameObject.Instantiate(ennemies[0]);

        nobj.transform.position = new Vector2((1 * 10), -(1 * 10));
        nobj.transform.localScale = new Vector3(1f, 1f, 1f);
        Ennemi e = nobj.GetComponent<Ennemi>();
        ennemic = e;
        foreach(Joueur j in joueursCIntanciate)
        {
            ennemic.joueurs.Add(j);
        }
        ennemisInstanciate.Add(nobj);
        nobj.SetActive(true);

    }
    public void changeCaseRecursif(Case c)
    {
        
        if (c.precedent != null)
        {
            c.changeRed();
            changeCaseRecursif(c.precedent);

        }
    }
    public void exitCaseRecursif(Case c)
    {
        
        if (c.precedent != null)
        {
            c.exit();
            exitCaseRecursif(c.precedent);

        }
    }
    public void exitCase(Case c)
    {
        if (!deplacement)
        {
            if (boardManager.contient(positionDeplacable, c.getX(), c.getY()))
            {
                exitCaseRecursif(c);
            }
        }
    }
    public void hover(Case c)
    {
        if (!deplacement) { 
            if (boardManager.contient(positionDeplacable, c.getX(), c.getY()))
            {
                changeCaseRecursif(c);
            }
            else
            {
                c.changeRed();
            }
        }

    }
    public void finDeplacement()
    {
        deplacement = false;
        gereDeplacementPossible();
    }
    public void finTour()
    {
        quiLeTour = !quiLeTour;
        if (quiLeTour)
        {
            Debug.Log("tour joueur");
        
            indexJoueur++;
            if (indexJoueur == 4)
            {
                indexJoueur = 0;
            }
            joueur = joueursIntanciate[indexJoueur];
            joueurc = joueur.GetComponent<Joueur>();
            debutTour();
        }
        else
        {
            Debug.Log("tour Ennemi");
            //ennemic = ennemisInstanciate[0].GetComponent<Ennemi>();
            debutTourEnnemi();
        }

        

    }
    public void debutTourEnnemi()
    {
        Debug.Log("debut tour ennemi");
        ennemic.setPm(ennemic.pmOrigine);
       Debug.Log( boardManager.grid[0, 0]);
        ennemic.joue(boardManager.grid,boardManager.tailleX,boardManager.tailleY);
        finTour();
    }
    public void debutTour()
    {
        Debug.Log("debut tour ally");
        gestionAffichageSort.j = joueurc;
        Debug.Log(gestionAffichageSort.j.sorts);
        gestionAffichageSort.afficheSort();
        joueurc.setPm(joueurc.pmOrigine);
        gereDeplacementPossible();
       
    }
    public void gereDeplacementPossible()
    {
        boardManager.reinitDistance();
        boardManager.reinitColor(positionDeplacable);
        Vector3 posJoueur = joueurc.transform.position;
        posJoueur.y = posJoueur.y * -1;
        positionDeplacable = boardManager.caseDeplacementPossible(posJoueur, joueurc);
        boardManager.changeColor(positionDeplacable);
    }
}
