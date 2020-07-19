using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class BoardManagerCombat : MonoBehaviour
{
    public List<GameObject> cases;
    public GameObject sol;
    Transform boardHolder;
    public Case[,] grid;
    public int tailleX;
    public int tailleY;
    public int possibilite = 3;
    private List<Vector3> gridPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
      /*
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {
                //Boolean isWall = ((y % 2) != 0) && (rnd.Next (0, 10) != 8);
                grid[x, y] = new Case(x, y, false);
                
            }
        }
        boardSetup();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reinitDistance()
    {
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {
                grid[y, x].distance = 0;
                grid[y, x].visite = false;
            }
        }
    }
    public void boardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject aintancier;
        int index;
        Vector3 ancienCentre;
        GameObject instance;
        grid = new Case[tailleY, tailleX];
        for (int x=0;x< tailleX; x++)
        {
            for(int y = 0; y < tailleY; y++)
            {

                GameObject nobj = (GameObject)GameObject.Instantiate(sol);

                nobj.transform.position = new Vector2(sol.transform.position.x + (1 * x), sol.transform.position.y + (1 * y));
                nobj.transform.localScale= new Vector3(0.95f, 0.95f, 0.95f);
                Case c=nobj.GetComponent<Case>();
                c.setVariable(x, y);
                grid[y,x] = c;

                nobj.gameObject.transform.parent = sol.transform.parent;
                nobj.SetActive(true);
                nobj.transform.SetParent(boardHolder);
            }
        }
    }
    
    public void afficheMap(TextAsset t)
    {
        Debug.Log(t.text);
        int l=0;
        int i = 0;
        int y=0;
        int x=0;
        string id="";
        int tampon;
        string charact;
        grid = new Case[tailleY, tailleX];
        boardHolder = new GameObject("Board").transform;
        while (i < t.text.Length )
        {
            charact = t.text.Substring(i, 1);
            if (charact != "," && charact != "/")
            {
                if (int.TryParse(charact,out tampon)) {
                    id = id + charact;
                }
                
            }
            else
            {
                
                GameObject nobj = (GameObject)GameObject.Instantiate(cases[int.Parse(id)]);
                id = "";
                nobj.transform.position = new Vector2(sol.transform.position.x + (1 * y), sol.transform.position.y + (-1 * x));
                nobj.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
                Case c = nobj.GetComponent<Case>();
                c.setVariable(y, x);
                grid[x, y] = c;
                nobj.gameObject.transform.parent = sol.transform.parent;
                nobj.SetActive(true);
                nobj.transform.SetParent(boardHolder);
                y++;
                if ( charact == "/")
                {
                    x++;
                    y = 0;
                }
            }

            i++;
        }
       /* 
        GameObject aintancier;
        int index;
        Vector3 ancienCentre;
        GameObject instance;
        grid = new Case[tailleY, tailleX];
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {

                GameObject nobj = (GameObject)GameObject.Instantiate(sol);

                nobj.transform.position = new Vector2(sol.transform.position.x + (1 * x), sol.transform.position.y + (1 * y));
                nobj.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
                Case c = nobj.GetComponent<Case>();
                c.setVariable(x, y, false);
                grid[y, x] = c;

                nobj.gameObject.transform.parent = sol.transform.parent;
                nobj.SetActive(true);
                nobj.transform.SetParent(boardHolder);
            }
        }*/
    }
    public void AjouteMurAleatoire()
    {

    }
    public List<Position> caseDeplacementPossible(Vector3 depart, Joueur j)
    {
        List<Position> casesPossible = new List<Position>();
        List<Case> casesVisite = new List<Case>();
        grid[(int)depart.y, (int)depart.x].precedent = null;
        casesVisite.Add(grid[(int)depart.y, (int)depart.x]);
        int iteration=0;

        while (casesVisite.Count != 0)
        {
            //Debug.Log(casesVisite[0].distance + " , " + casesVisite[0].getY() + ", " + casesVisite[0].getX());
          // Debug.Log("position" + casesVisite[0].getX() + ", " + casesVisite[0].getY());
           //Debug.Log(grid[casesVisite[0].getY(), casesVisite[0].getX()].distance);
            if (grid[casesVisite[0].getY(), casesVisite[0].getX()].mur || contient(casesPossible, casesVisite[0].getX(), casesVisite[0].getY()) || grid[casesVisite[0].getY(), casesVisite[0].getX()].visite || grid[casesVisite[0].getY(), casesVisite[0].getX()].distance > j.getPm())
            {
               // Debug.Log("remove a cause d'un prob");
                casesVisite.RemoveAt(0);
            }
            else
            {
                if (casesVisite[0].distance != 0 && casesVisite[0].distance <= j.getPm())
                {
                    //Debug.Log("ajout au position");
                    casesPossible.Add(new Position(casesVisite[0].getX(), casesVisite[0].getY(), casesVisite[0].distance, casesVisite[0].precedent));
                }

                if (casesVisite[0].getY() + 1 >= 0 && casesVisite[0].getY() + 1 < tailleY && !grid[(casesVisite[0].getY() + 1), casesVisite[0].getX()].visite)
                {
                    grid[(casesVisite[0].getY() + 1), casesVisite[0].getX()].distance = grid[casesVisite[0].getY(), casesVisite[0].getX()].distance + 1;
                    grid[(casesVisite[0].getY() + 1), casesVisite[0].getX()].precedent = grid[casesVisite[0].getY(), casesVisite[0].getX()];
                    casesVisite.Add(grid[casesVisite[0].getY() + 1, casesVisite[0].getX()]);
                    //Debug.Log("ajout monte");
                }
                
                 if (casesVisite[0].getY() - 1 >= 0 && casesVisite[0].getY() - 1 < tailleY && !grid[(casesVisite[0].getY() - 1), casesVisite[0].getX()].visite)
                 {
                    grid[(casesVisite[0].getY() - 1), casesVisite[0].getX()].distance = grid[casesVisite[0].getY(), casesVisite[0].getX()].distance + 1;
                    grid[(casesVisite[0].getY() - 1), casesVisite[0].getX()].precedent = grid[casesVisite[0].getY(), casesVisite[0].getX()];
                   casesVisite.Add(grid[casesVisite[0].getY() - 1, casesVisite[0].getX()]);
                    //Debug.Log("ajout descend");
                }
                 if (casesVisite[0].getX() + 1 >= 0 && casesVisite[0].getX() + 1 < tailleX && !grid[(casesVisite[0].getY()), casesVisite[0].getX() + 1].visite)
                 {
                    grid[(casesVisite[0].getY()), casesVisite[0].getX()+1].distance = grid[casesVisite[0].getY(), casesVisite[0].getX()].distance + 1;
                    grid[(casesVisite[0].getY()), casesVisite[0].getX() + 1].precedent= grid[casesVisite[0].getY(), casesVisite[0].getX()];
                    casesVisite.Add(grid[casesVisite[0].getY(), casesVisite[0].getX()+1]);
                   // Debug.Log("ajout droite");

                }
                 if (casesVisite[0].getX() - 1 >= 0 && casesVisite[0].getX() - 1 < tailleX && !grid[(casesVisite[0].getY()), casesVisite[0].getX() - 1].visite)
                 {
                    grid[(casesVisite[0].getY()), casesVisite[0].getX() - 1].distance = grid[casesVisite[0].getY(), casesVisite[0].getX()].distance + 1;
                    grid[(casesVisite[0].getY()), casesVisite[0].getX() - 1].precedent = grid[casesVisite[0].getY(), casesVisite[0].getX()];
                    casesVisite.Add(grid[casesVisite[0].getY(), casesVisite[0].getX() - 1]);
                    //Debug.Log("ajout gauche");
                }
                casesVisite[0].visite = true;
                casesVisite.RemoveAt(0);


                //}
            }
        }
        return casesPossible;
    }
    public bool contient(List<Position> casesPossible, int x, int y)
    {
        foreach(Position pos in casesPossible)
        {
            if (pos.posX == x && pos.posY == y)
            {
                return true;
            }
        }
        return false;
    }
    public void changeColor(List<Position> posPossible)
    {
        foreach (Position pos in posPossible)
        {
            grid[pos.posY, pos.posX].changeColor();
        }
       
        
    }
    public void reinitColor(List<Position> posPossible)
    {
        if (posPossible == null)
        {
            return;
        }
        foreach (Position pos in posPossible)
        {
            grid[pos.posY, pos.posX].initColor();
        }


    }
    
}
