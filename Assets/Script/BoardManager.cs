using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class BoardManager : MonoBehaviour
{
    public GameObject[] lieux;
    Transform boardHolder;
    public int tailleX;
    public int tailleY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void boardSetup()
    {
        boardHolder = new GameObject("Board").transform;
        GameObject aintancier;
        aintancier = lieux[Random.Range(0, lieux.Length)];        
        GameObject instance = Instantiate(aintancier, new Vector3(0, 0, 0f), Quaternion.identity);
        instance.transform.SetParent(boardHolder);
            
    }
}
