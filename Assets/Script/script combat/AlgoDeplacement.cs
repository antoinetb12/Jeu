using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AlgoDeplacement : MonoBehaviour
{


    public abstract List<Case> FindPath(Vector3 startPos, Vector3 targetPos, Case[,] grid, int dimX, int dimY);
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
