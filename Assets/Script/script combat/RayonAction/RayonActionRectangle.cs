using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonActionRectangle : RayonAction
{
    public int x;
    public int y;

    public override List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY)
    {
        int direction= getDirection(startPos, targetCase);
        int xUtilisable = (x - 1) / 2;
        int yUtilisable = (y - 1) / 2;
        if (direction==0)
        {
            if (x > y)
            {
                xUtilisable = (y - 1) / 2;
                yUtilisable = (y - 1) / 2;
            }
            else
            {
                xUtilisable = (x - 1) / 2;
                yUtilisable = (x - 1) / 2;
            }

        }else if (direction == 2)
        {
            xUtilisable = (y - 1) / 2;
            yUtilisable = (x - 1) / 2;
        }
        List<Position> positions = new List<Position>();
        
        int debutx= targetCase.getX() - xUtilisable;
        int finx= targetCase.getX() + xUtilisable;
        int debuty=targetCase.getY() - yUtilisable;
        int finy=targetCase.getY() + yUtilisable;
        
        if (targetCase.getX() - xUtilisable < 0)
        {
            debutx = 0;
        }
        if (targetCase.getY() - yUtilisable < 0)
        {
            debuty = 0;
        }
        if (targetCase.getX() + xUtilisable >= dimX)
        {
            finx = dimX-1;
        }
        if (targetCase.getY() + yUtilisable >= dimY)
        {
            finy = dimY - 1;
        }
        int debutyInitial= debuty;
        for(; debutx <= finx; debutx++)
        {
            for (debuty = debutyInitial; debuty <= finy; debuty++)
            {
                positions.Add(new Position(grid[debuty,debutx].getX(), grid[debuty, debutx].getY(), GetDistanceDeLaCase(grid[debuty, debutx], targetCase), null));
            }
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
    public int getDirection(Vector3 startPos, Case targetCase)
    {
        int dstX = Mathf.Abs((int)startPos.x - targetCase.getX());
        int dstY = Mathf.Abs((int)(-startPos.y) - targetCase.getY());
        Debug.Log("dstX : " + dstX + ", " + dstY);
        if (dstX == dstY)
            return 0;
        else if(dstX > dstY) {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
