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

    public void boardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject aintancier;
        int index;
        Vector3 ancienCentre;
        GameObject instance;
        grid = new Case[tailleX, tailleY];
        for (int x=0;x< tailleX; x++)
        {
            for(int y = 0; y < tailleY; y++)
            {

                GameObject nobj = (GameObject)GameObject.Instantiate(sol);
                nobj.transform.position = new Vector2(sol.transform.position.x + (1 * y), sol.transform.position.y + (1 * x));
                nobj.transform.localScale= new Vector3(0.95f, 0.95f, 0.95f);
                Case c=nobj.GetComponent<Case>();
                c.setVariable(x, y, false);
                grid[x,y] = c;

                nobj.gameObject.transform.parent = sol.transform.parent;
                nobj.SetActive(true);
                nobj.transform.SetParent(boardHolder);
            }
        }/*
        for (int i = 0; i < possibilite; i++)
        {
            index = Random.Range(0, cases.Count);
            aintancier = cases[index];
            cases.RemoveAt(index);
            aintancier.GetComponent<Lieu>().centerPosition=new Vector3(ancienCentre.x + (6f * i), ancienCentre.y, ancienCentre.z);
           
        }*/
        
            
    }
    public void caseDeplacement(Vector3 depart, int range)
    {
        grid[(int)depart.y, (int)depart.x].changeColor();
    }
}
