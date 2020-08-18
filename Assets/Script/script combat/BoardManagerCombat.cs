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
    public GameObject ligne;


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
    public void reinitDistanceSort()
    {
        for (int x = 0; x < tailleX; x++)
        {
            for (int y = 0; y < tailleY; y++)
            {
                grid[y, x].distanceSort = 0;
                grid[y, x].visite = false;
            }
        }
    }
    
    public void afficheMap(TextAsset t)
    {       
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
                
                nobj.transform.localScale = new Vector3(1f, 1f, 1f);
                Case c = nobj.GetComponent<Case>();
                c.setVariable(y, x);
                grid[x, y] = c;
                nobj.gameObject.transform.parent = sol.transform.parent;
                nobj.SetActive(true);
                nobj.transform.SetParent(boardHolder);
                y++;
                instanciateLine(x, y,true);
                instanciateLine(x, y, false);
                if (x == tailleX - 1)
                {
                    instanciateLine(x+1, y , false);
                }
                if ( charact == "/")
                {
                    instanciateLine(x, y+1, true);
                    x++;
                    
                    y = 0;
                }
            }

            i++;
        }
        
        Debug.Log("fin de l'instaciation de la map");
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
    public void instanciateLine(int x,int y,bool horizon)
    {
        GameObject ligne = (GameObject)GameObject.Instantiate(this.ligne);
        if (horizon)
        {
            ligne.transform.position = new Vector3(sol.transform.position.x + (1 * y) - 1.5f, sol.transform.position.y + (-1 * x), -1);
            ligne.transform.localScale = new Vector3(0.04f, 1f, 1f);

        }
        else
        {
            ligne.transform.position = new Vector3(sol.transform.position.x + (1 * y)-1 , sol.transform.position.y + (-1 * x)+0.5f, -1);
            ligne.transform.localScale = new Vector3(1f, 0.04f, 1f);

        }

        ligne.gameObject.transform.parent = sol.transform.parent;
        ligne.SetActive(true);
        ligne.transform.SetParent(boardHolder);
    }
    public void AjouteMurAleatoire()
    {

    }
    public void removePerso(Vector3 position)
    {
        Case departc = grid[-(int)position.y, (int)position.x];
        departc.perso = null;
    }
    public void ajoutePerso(Vector3 position, Personnage p)
    {
        Case departc = grid[-(int)position.y, (int)position.x];
        departc.perso = p;
    }
    public List<Position> caseAttaquable(Sort s, Vector3 depart)
    {
        List<Position> casesPossible = new List<Position>();
        Case departc = grid[(int)depart.y, (int)depart.x];

        if (s.range == 1)
        {
            if (departc.getY() + 1 >= 0 && departc.getY() + 1 < tailleY && !grid[(departc.getY() + 1), departc.getX()].mur)
            {
                casesPossible.Add(new Position(departc.getX(), departc.getY() + 1, 1, departc));
                //Debug.Log("ajout monte");
            }

            if (departc.getY() - 1 >= 0 && departc.getY() - 1 < tailleY && !grid[(departc.getY() - 1), departc.getX()].mur)
            {
                casesPossible.Add(new Position(departc.getX(), departc.getY() - 1, 1, departc));
                //Debug.Log("ajout descend");
            }
            if (departc.getX() + 1>= 0 && departc.getX() + 1 < tailleX && !grid[(departc.getY()), departc.getX() + 1].mur)
            {

                casesPossible.Add(new Position(departc.getX() + 1, departc.getY(), 1, departc));
            }
            if (departc.getX() - 1 >= 0 && departc.getX() - 1 < tailleX && !grid[(departc.getY()), departc.getX() - 1].mur)
            {
                casesPossible.Add(new Position(departc.getX() - 1, departc.getY() , 1, departc));
                //Debug.Log("ajout gauche");
            }
        }
        else
        {
            foreach(Position p in BfsAttaque(depart, s))
            {
                //Debug.Log("position :   , " + p.posX + "," + p.posY);
               // casesPossible.Add(new Position(p.posX, p.posY, 1, p.precedent));
               if(GetDistance(grid[(int)depart.y, (int)depart.x], grid[p.posY, p.posX]) > s.rangeMin)
                {
                    if(s.besoinLdv  && tracerSegment(grid[(int)depart.y, (int)depart.x], grid[p.posY, p.posX]))
                     {
                         casesPossible.Add(new Position(p.posX, p.posY, 1, p.precedent));
                     }else if(!s.besoinLdv && !grid[p.posY, p.posX].mur)
                    {
                        casesPossible.Add(new Position(p.posX, p.posY, 1, p.precedent));

                    }
                }
            }
        }
        return casesPossible;
    }
    public List<Position> BfsAttaque(Vector3 depart, Sort s)
    {
        List<Position> casesPossible = new List<Position>();
        List<Position> murTrouve = new List<Position>();
        List<Case> casesVisite = new List<Case>();
        grid[(int)depart.y, (int)depart.x].distanceSort = 0;
        casesVisite.Add(grid[(int)depart.y, (int)depart.x]);
        while (casesVisite.Count != 0)
        {
            //Debug.Log(casesVisite[0].distance + " , " + casesVisite[0].getY() + ", " + casesVisite[0].getX());
            // Debug.Log("position" + casesVisite[0].getX() + ", " + casesVisite[0].getY());
            //Debug.Log(grid[casesVisite[0].getY(), casesVisite[0].getX()].distance);
            if ( grid[casesVisite[0].getY(), casesVisite[0].getX()].visite || grid[casesVisite[0].getY(), casesVisite[0].getX()].distanceSort > s.range)
            {
                // Debug.Log("remove a cause d'un prob");
                casesVisite.RemoveAt(0);
            }
            else
            {
                if (casesVisite[0].distanceSort != 0 && casesVisite[0].distanceSort <= s.range)
                {
                    //Debug.Log("ajout au position");
                    casesPossible.Add(new Position(casesVisite[0].getX(), casesVisite[0].getY(), casesVisite[0].distanceSort, null));
                }

                if (casesVisite[0].getY() + 1 >= 0 && casesVisite[0].getY() + 1 < tailleY && !grid[(casesVisite[0].getY() + 1), casesVisite[0].getX()].visite)
                {
                    grid[(casesVisite[0].getY() + 1), casesVisite[0].getX()].distanceSort = grid[casesVisite[0].getY(), casesVisite[0].getX()].distanceSort + 1;
                    casesVisite.Add(grid[casesVisite[0].getY() + 1, casesVisite[0].getX()]);
                    //Debug.Log("ajout monte");
                }

                if (casesVisite[0].getY() - 1 >= 0 && casesVisite[0].getY() - 1 < tailleY && !grid[(casesVisite[0].getY() - 1), casesVisite[0].getX()].visite)
                {
                    grid[(casesVisite[0].getY() - 1), casesVisite[0].getX()].distanceSort = grid[casesVisite[0].getY(), casesVisite[0].getX()].distanceSort + 1;
                    casesVisite.Add(grid[casesVisite[0].getY() - 1, casesVisite[0].getX()]);
                    //Debug.Log("ajout descend");
                }
                if (casesVisite[0].getX() + 1 >= 0 && casesVisite[0].getX() + 1 < tailleX && !grid[(casesVisite[0].getY()), casesVisite[0].getX() + 1].visite)
                {
                    grid[(casesVisite[0].getY()), casesVisite[0].getX() + 1].distanceSort = grid[casesVisite[0].getY(), casesVisite[0].getX()].distanceSort + 1;
                    casesVisite.Add(grid[casesVisite[0].getY(), casesVisite[0].getX() + 1]);
                    // Debug.Log("ajout droite");

                }
                if (casesVisite[0].getX() - 1 >= 0 && casesVisite[0].getX() - 1 < tailleX && !grid[(casesVisite[0].getY()), casesVisite[0].getX() - 1].visite)
                {
                    grid[(casesVisite[0].getY()), casesVisite[0].getX() - 1].distanceSort = grid[casesVisite[0].getY(), casesVisite[0].getX()].distanceSort + 1;
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

    //TODO si lors d'un add c'est un mur alors on return false;
    public bool tracerSegment(Case p1, Case p2)
    {
        if (p2.mur)
        {
            return false;
        }
        List<Case> tuiles = new List<Case>();
        int dx, dy, x, y, incrmX, incrmY;
        int ratio;
        int result = 0;
        int step;
        dx = p2.getX() - p1.getX();
        dy = p2.getY() - p1.getY();
        if (dx > 0)
            incrmX = 1;
        else
        {
            incrmX = -1;
            dx *= -1;
        }

        if (dy > 0)
            incrmY = 1;
        else
        {
            incrmY = -1;
            dy *= -1;
        }

        if (dx >= dy)
        {
            y = p1.getY();
            ratio = dy;
            step = dx;
            result = step;
            result -= ratio;
            if (result == 0)
            {
                y += incrmY;
                result += step * 2;
            }
            
            for (x = p1.getX() + incrmX; x != p2.getX(); x += incrmX)
            {
                result -= ratio * 2;
                if (bloqueLdv(grid[y, x]) && grid[y, x].perso == null || bloqueLdv(grid[y, x]) && grid[y, x].perso != null && grid[y, x] != p2)
                {
                    return false;
                }
                while (result < 0)
                {
                    
                    tuiles.Add(grid[y, x]);
                    result += step * 2;
                    y += incrmY;
                }
               
                tuiles.Add(grid[y, x]);
                if (result == 0)
                {
                    y += incrmY;
                    result += step * 2;
                }

            }
            
        }
        else
        {
            x = p1.getX();
            ratio = dx;
            step = dy;
            result = step;
            result -= ratio;
            
            for (y = p1.getY() + incrmY; y != p2.getY(); y += incrmY)
            {
                if (bloqueLdv(grid[y, x]) && grid[y, x].perso == null || bloqueLdv(grid[y, x]) && grid[y, x].perso != null && grid[y, x] != p2)
                {
                    return false;
                }
                result -= ratio * 2;
                while (result < 0)
                {
                   
                    tuiles.Add(grid[y, x]);
                    result += step * 2;
                    x += incrmX;
                }
                
                tuiles.Add(grid[y, x]);
                if (result == 0)
                {
                    x += incrmX;
                    result += step * 2;
                }

            }
        }



        return true;
    }


    public bool bloqueLdv(Case x)
    {
        return x.mur || x.perso!=null;
    }
    public List<Position> caseDeplacementPossible(Vector3 depart, Joueur j)
    {
        List<Position> casesPossible = new List<Position>();
        List<Case> casesVisite = new List<Case>();
        grid[(int)depart.y, (int)depart.x].precedent = null;
        casesVisite.Add(grid[(int)depart.y, (int)depart.x]);

        while (casesVisite.Count != 0)
        {
            //Debug.Log(casesVisite[0].distance + " , " + casesVisite[0].getY() + ", " + casesVisite[0].getX());
          // Debug.Log("position" + casesVisite[0].getX() + ", " + casesVisite[0].getY());
           //Debug.Log(grid[casesVisite[0].getY(), casesVisite[0].getX()].distance);
            if (grid[casesVisite[0].getY(), casesVisite[0].getX()].mur || (grid[casesVisite[0].getY(), casesVisite[0].getX()].distance!=0 && grid[casesVisite[0].getY(), casesVisite[0].getX()].perso != null)  || grid[casesVisite[0].getY(), casesVisite[0].getX()].visite || grid[casesVisite[0].getY(), casesVisite[0].getX()].distance > j.getPm())
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
        if (casesPossible == null)
        {
            return false;
        }
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
            grid[pos.posY, pos.posX].changeColor(Color.yellow);
        }
       
        
    }
    public void changeColorCase(List<Case> posPossible)
    {
        foreach (Case pos in posPossible)
        {
            grid[pos.getY(), pos.getX()].changeColor(Color.black);
        }


    }
    public void changeColorAttaque(List<Position> posPossible)
    {
        foreach (Position pos in posPossible)
        {
            /*if(grid[pos.posY, pos.posX].perso == null)
            {
                
            }
            else
            {
                //grid[pos.posY, pos.posX].changeColor(Color.blue);

            }*/
            grid[pos.posY, pos.posX].changeColor(Color.magenta);
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
    public void changeColor(List<Position> posPossible,Color color)
    {
        if (posPossible == null)
        {
            return;
        }
        foreach (Position pos in posPossible)
        {
            if (grid[pos.posY, pos.posX].perso == null)
            {
                grid[pos.posY, pos.posX].changeColorHover(color);
            }
            else
            {
                grid[pos.posY, pos.posX].changeColorHover(Color.blue);

            }
           
        }


    }
    public void exit(List<Position> posPossible)
    {
        if (posPossible == null)
        {
            return;
        }
        foreach (Position pos in posPossible)
        {
            grid[pos.posY, pos.posX].exit();
        }


    }
    int GetDistance(Case nodeA, Case nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());
        return dstX + dstY;
    }
    public List<Case> getAllCase(List<Position> p)
    {
        List<Case> cs = new List<Case>();
        foreach (Position pa in p)
        {
           cs.Add( grid[pa.posY, pa.posX]);
        }
        return cs;
    }
    public Case getCase(Vector3 posJoueur)
    {
        Debug.Log(grid[(int)-posJoueur.y, (int)posJoueur.x]);
        return grid[(int)-posJoueur.y,(int) posJoueur.x];
    }
}
