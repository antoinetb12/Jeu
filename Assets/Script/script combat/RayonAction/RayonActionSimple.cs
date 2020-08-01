using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonActionSimple : RayonAction
{

    public override List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY)
    {
        List<Position> positions = new List<Position>();
        positions.Add(new Position(targetCase.getX(), targetCase.getY(), 0, null));
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
}
