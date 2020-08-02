using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleurCombat : MonoBehaviour
{
    public static ControleurCombat instance =null;
    private BoardManagerCombat boardManager;
    public List<GameObject> joueurs;
    public List<GameObject> ennemies;
    private List<GameObject> joueursIntanciate=new List<GameObject>();
    private List<Joueur> joueursCIntanciate = new List<Joueur>();
    private List<GameObject> ennemisInstanciate = new List<GameObject>();
    private Joueur joueurc;
    private Ennemi ennemic;
    public List<TextAsset> listMap;
    private GestionAffichageSort gestionAffichageSort;
    bool deplacement = false;
    bool choisiSort = false;
    private Sort sortSelectionne;
    private int indexJoueur;
    List<Position> positionDeplacable;
    List<Position> positionAttaquable;
    Case caseHover=null;
    List<Position> rayonAction = null;
    List<Personnage> personnages = new List<Personnage>();
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
        //initGame();
        loadSave();
        
    }

    public void setDeplacement(bool deplacement)
    {
        this.deplacement = deplacement;
    }
    public void selectionneSort(Sort s)
    {
        if (!deplacement)
        {

        
            Debug.Log("lance sort ");
            if (sortSelectionne !=null && sortSelectionne.nom == s.nom)
            {
            
                choisiSort = false;
                sortSelectionne = null;
                boardManager.reinitColor(positionAttaquable);
                boardManager.changeColor(positionDeplacable);
                boardManager.reinitDistanceSort();

            }else if(sortSelectionne != null && sortSelectionne.nom != s.nom)
            {
                sortSelectionne = s;
                choisiSort = true;
                boardManager.reinitColor(positionAttaquable);
                boardManager.reinitDistanceSort();
                Vector3 posJoueur = joueurc.transform.position;
                posJoueur.y = posJoueur.y * -1;
                positionAttaquable = boardManager.caseAttaquable(s, posJoueur);
                boardManager.changeColorAttaque(positionAttaquable);
            }
            else
            {
                choisiSort = true;
                sortSelectionne = s;
                boardManager.reinitColor(positionDeplacable);
                boardManager.reinitDistanceSort();
                Vector3 posJoueur = joueurc.transform.position;
                posJoueur.y = posJoueur.y * -1;
                positionAttaquable= boardManager.caseAttaquable(s, posJoueur);
                boardManager.changeColorAttaque(positionAttaquable);
            }
        }
    }
    public void click(Case c)
    {
        if (!deplacement)
        {

            if (choisiSort)
            {
                if (boardManager.contient(positionAttaquable, c.getX(), c.getY()))
                {
                    if (joueurc.lanceSort(sortSelectionne))
                    {
                        foreach(Case ca in boardManager.getAllCase(rayonAction))
                        {
                            if (ca.perso != null)
                            {

                                ca.perso.recoitAttaque(sortSelectionne);
                                if (ca.perso.pdv <= 0)
                                {
                            
                           
                                    foreach(GameObject e in ennemisInstanciate)
                                    {
                                        Debug.Log(e.GetComponent<Ennemi>().pdv);
                                        if (e.GetComponent<Ennemi>() == ca.perso)
                                        {
                                            ennemic = null;
                                            Destroy(e);
                                        }
                                    }
                                    ca.perso = null;

                                }
                            }
                        }
                    }
                    choisiSort = false;
                    sortSelectionne = null;
                    boardManager.reinitColor(positionAttaquable);
                    boardManager.reinitColor(rayonAction);
                    boardManager.reinitDistance();
                    gereDeplacementPossible();

                }
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
    public void loadSave()
    {
        ProgressionData data = SaveSystem.LoadProgression();
        List<GameObject> joueurChoisi = new List<GameObject>();
        if (data != null)
        {
            foreach(string nom in data.personnages)
            {
                joueurChoisi.Add(findJoueur(nom));
            }
        }
        else
        {
            joueurChoisi.Add(findJoueur("j1"));
        }
        initGame(joueurChoisi);
        
    }
    public GameObject findJoueur(string name) {
        foreach(GameObject g in joueurs)
        {
            Personnage p=g.GetComponent<Personnage>();
            if (p.nom == name)
            {
                return g;
            }
        }
        return null;
    }
    void initGame(List<GameObject> joueurChoisi)
    {
        boardManager.afficheMap(listMap[0]);
        foreach (GameObject g in joueurChoisi)
        {
            print(g);
            GameObject nobj = (GameObject)GameObject.Instantiate(g);
            joueursCIntanciate.Add(nobj.GetComponent<Joueur>());
            boardManager.ajoutePerso(nobj.transform.position, nobj.GetComponent<Joueur>());
            nobj.SetActive(true);
            personnages.Add(nobj.GetComponent<Personnage>());
        }
        indexJoueur = 0;
        joueurc = joueursCIntanciate[indexJoueur];
        
        initEnnemies();
        DetermineOrdre();


        Debug.Log(boardManager.grid[0, 0]);
        debutTour();

        //joueur = GameObject.FindGameObjectWithTag("Player").GetComponent<Joueur>();
    }
    public void SaveAll()
    {
        List<string> playerName = new List<string>();
        foreach(Personnage p in personnages)
        {

            if (p.getStatusPersonnage() == 0)
            {
                playerName.Add(p.nom);
                p.SavePlayer();
            }

        }
        SaveSystem.SaveProgression(playerName, 0);
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
        boardManager.ajoutePerso(e.transform.position, e);
        nobj.SetActive(true);
        personnages.Add(e);

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
            if (!choisiSort)
            {
                if (boardManager.contient(positionDeplacable, c.getX(), c.getY()))
                {
                    exitCaseRecursif(c);
                }
            }

            else
            {
                if (boardManager.contient(positionAttaquable, c.getX(), c.getY()))
                {
                    boardManager.exit(rayonAction);
                }
            }
        }
    }
    public void hover(Case c)
    {
        
        if (!deplacement ) {
            if (!choisiSort)
            {
                if (boardManager.contient(positionDeplacable, c.getX(), c.getY()))
                {
                    changeCaseRecursif(c);
                }
                else
                {
                    c.changeRed();
                }
            }
            else
            {
                if(boardManager.contient(positionAttaquable, c.getX(), c.getY()))
                {
                    if (caseHover != c)
                    {
                        rayonAction = sortSelectionne.GetRayon(joueurc.transform.position, c, boardManager.grid, boardManager.tailleX, boardManager.tailleY);
                        boardManager.changeColor(rayonAction, Color.green);
                    }
                }
            }

           // boardManager.changeColorCase(boardManager.tracerSegment(boardManager.grid[-(int)joueurc.transform.position.y, (int)joueurc.transform.position.x], c));
        }
        caseHover = c;

    }
    public void finDeplacement(Vector3 positionDebut, Vector3 positionFin, Personnage p)
    {
        Debug.Log("fin deplacement");
        boardManager.removePerso(positionDebut);
        boardManager.ajoutePerso(positionFin, p);
        deplacement = false;
        if (ennemic != null)
        {

        }
        else
        {
            reinitialiseAffichageDeplacement();
            gereDeplacementPossible();
        }
        
    }
    
    int SortByScore(Personnage p1, Personnage p2)
    {
        return p2.initiative.CompareTo(p1.initiative);
    }
    public void DetermineOrdre()
    {
        personnages.Sort(SortByScore);
    }
    public void finTour()
    {
        Debug.Log("tour joueur");
        
        indexJoueur++;
        if (indexJoueur == personnages.Count)
        {
            indexJoueur = 0;
        }
        debutTour();
    }
    public void meurt()
    {
        if (!encoreEnVie(0))
        {
            GameOver();
        }
        else if (!encoreEnVie(1))
        {
            Debug.Log("fin de ce niveau");
        }
    }
    public void GameOver()
    {
        DontDestroyOnLoadScene.instance.removeDontDestroyOnLoad();
        SceneManager.LoadScene("MenuPrincipal");
    }
    public bool encoreEnVie(int statutPerso)
    {
        foreach (Personnage p in personnages)
        {
            if (p.getStatusPersonnage() == statutPerso && p.pdv>0)
            {
                return true;
            }
        }
        return false;
    }

    public void debutTour()
    {

        Personnage p = personnages[indexJoueur].GetComponent<Personnage>();
        if (p.getStatusPersonnage() == 0)
        {
            joueurc = (Joueur)p;
            Debug.Log("debut tour ally");
            gestionAffichageSort.j = joueurc;
            Debug.Log(gestionAffichageSort.j.sorts);
            gestionAffichageSort.afficheSort();
            joueurc.setPm(joueurc.pmOrigine);
            choisiSort = false;
            sortSelectionne = null;
            boardManager.reinitColor(positionAttaquable);
            boardManager.reinitDistanceSort();
            reinitialiseAffichageDeplacement();
            gereDeplacementPossible();
        }
        else
        {
            ennemic = (Ennemi)p;
            ennemic.setPm(ennemic.pmOrigine);
            ennemic.joue(boardManager.grid, boardManager.tailleX, boardManager.tailleY);
            ennemic = null;
        }
       
       
    }
    public void reinitialiseAffichageDeplacement()
    {
        boardManager.reinitDistance();
        boardManager.reinitColor(positionDeplacable);
    }
    public void gereDeplacementPossible()
    {
        Vector3 posJoueur = joueurc.transform.position;
        posJoueur.y = posJoueur.y * -1;
        positionDeplacable = boardManager.caseDeplacementPossible(posJoueur, joueurc);
        boardManager.changeColor(positionDeplacable);
    }
}
