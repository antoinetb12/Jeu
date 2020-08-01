using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonActionCercle : RayonAction
{
    public int rayon;

    public override List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY)
    {
        List<Position> positions = new List<Position>();

        List<Case> caseAVisite = new List<Case>();
        List<Case> caseDejaVisite = new List<Case>();
        Case c;
        caseAVisite.Add(targetCase);
        while (caseAVisite.Count > 0)
        {
            c = caseAVisite[0];
            foreach (Case ca in GetNeighbours(c, dimX, dimY, grid))
            {
                if(!caseDejaVisite.Contains(ca) && GetDistanceDeLaCase(targetCase, ca) <= (rayon - 1) / 2)
                {
                    positions.Add(new Position(ca.getX(), ca.getY(), GetDistanceDeLaCase(ca, targetCase), null));
                    caseDejaVisite.Add(ca);
                    caseAVisite.Add(ca);
                }
               
            }
            caseAVisite.RemoveAt(0);

        }
        
        return positions;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int GetDistance(Case nodeA, Case nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());

        if (dstX > dstY)
            return  dstY +  (dstX - dstY);
        return  dstX +  (dstY - dstX);
    }
    public List<Case> GetNeighbours(Case c, int dimX, int dimY, Case[,] grid)
    {
        List<Case> neighbours = new List<Case>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = c.getX() + x;
                int checkY = c.getY() + y;

                if (checkX >= 0 && checkX < dimX && checkY >= 0 && checkY < dimY)
                {
                    neighbours.Add(grid[checkY, checkX]);
                }
            }
        }

        return neighbours;
    }
}
