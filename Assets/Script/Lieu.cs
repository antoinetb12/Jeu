using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lieu : MonoBehaviour
{
    public string nom;
    public Vector3 centerPositionBase;
    private Vector3 centerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setCenterPosition(Vector3 v)
    {
        print("vector " + v);
        centerPosition = v;
        print(centerPosition);
    }
    public Vector3 getCenterPosition()
    {
        print(centerPosition);
        return centerPosition;
    }
    public void PrintName()
    {
        print(nom);
        getCenterPosition();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
