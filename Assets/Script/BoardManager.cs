using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class BoardManager : MonoBehaviour
{
    public List<GameObject> lieux;
    Transform boardHolder;
    public int tailleX;
    public int tailleY;
    public int possibilite = 3;
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
        int index;
        Vector3 ancienCentre;
        GameObject instance;
        for (int i = 0; i < possibilite; i++)
        {
            index = Random.Range(0, lieux.Count);
            aintancier = lieux[index];
            lieux.RemoveAt(index);
            ancienCentre = aintancier.GetComponent<Lieu>().centerPositionBase;
            aintancier.GetComponent<Lieu>().setCenterPosition(new Vector3(ancienCentre.x + (6f * i), ancienCentre.y, ancienCentre.z));
            instance = Instantiate(aintancier, new Vector3(i*(6f), 0, 0f), Quaternion.identity);
            instance.transform.localScale = new Vector3(6f, 6f, 4f);
            instance.transform.SetParent(boardHolder);
        }

            
    }
}
