using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class RayonAction : MonoBehaviour
{


    public abstract List<Position> GetRayon(Vector3 startPos, Case targetCase, Case[,] grid, int dimX, int dimY);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected int GetDistanceDeLaCase(Case nodeA, Case nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());
        return dstX + dstY;
    }

}
