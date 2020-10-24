using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Personnage
{
    private AlgoDeplacement algo;
    public List<Joueur> joueurs;
    private Case[,] grid;
    private Joueur jChoisi=null;
    //TODO instancier chaque sort
    // Start is called before the first frame update
    void Start()
    {
        if (algo == null)
        {
            algo = GetComponent<AlgoDeplacement>();
        }
        foreach (GameObject g in sortsG)
        {
            Sorts.Add(g.GetComponent<Sort>());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
    public void joue(Case[,] grid, int dimX, int dimY)
    {
        this.grid = grid;
        List<Case> cheminChoisi=null;
        List<Case> chemin;
        foreach (Joueur j in joueurs)
        {
            Debug.Log("joueur " + j);
            if (j.pdv > 0)
            {
                if (algo == null)
                {
                    algo = GetComponent<AlgoDeplacement>();
                }
                chemin = algo.FindPath(transform.position, j.transform.position, grid, dimX, dimY);
            }
            else
            {
                chemin = null;
            }
            if (cheminChoisi == null)
            {
                cheminChoisi = chemin;
                jChoisi = j;
            }
            else if(chemin!=null)
            {
                if (cheminChoisi.Count - 1 <= getPm() && chemin.Count-1 <= getPm())
                {
                    if (jChoisi.pdv > j.pdv)
                    {
                        cheminChoisi = chemin;
                        jChoisi = j;
                    }
                }
                else if(cheminChoisi.Count>chemin.Count)
                {
                    cheminChoisi = chemin;
                    jChoisi = j;
                }
            }
            
        }


        cheminChoisi.RemoveAt(cheminChoisi.Count - 1);
        while (cheminChoisi.Count > getPm())
        {
            cheminChoisi.RemoveAt(cheminChoisi.Count - 1);
        }
        
        StartCoroutine(smoothMovement(cheminChoisi));
    }
    int GetDistance(Case nodeA, Case nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());
        Debug.Log("get distance : " + dstX + ", " + dstY);
        return dstX+ dstY;
    }

    public override void finMouvement()
    {
        Case startNode = grid[Mathf.RoundToInt(-transform.position.y), Mathf.RoundToInt(transform.position.x)];
        Case targetNode = grid[Mathf.RoundToInt(-jChoisi.transform.position.y), Mathf.RoundToInt(jChoisi.transform.position.x)];
        Sort s = Sorts[0];
        if (GetDistance(startNode, targetNode) <= s.range && s.cout <= pa)
        {
            GetComponent<Animator>().SetTrigger("attaque1");
            jChoisi.recoitAttaque(s.pdd);
        }
        ControleurCombat.instance.finTour();
    }
    public override void recoitAttaque(int degat)
    {
        base.recoitAttaque(degat);
        if (degat!=0) { 
        pdv = pdv - degat;
        Debug.Log("ennemy recoit attaque de "+ degat + " ouch plus que "+pdv );
        
            if (pdv <= 0)
            {

                ControleurCombat.instance.meurt();

            }
        }
    }

    public override int getStatusPersonnage()
    {
        return 1;
    }
}
