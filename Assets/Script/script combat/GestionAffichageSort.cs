using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAffichageSort :MonoBehaviour
{
    public Joueur j;
    private List<GameObject> sorts=new List<GameObject>();
    // Start is called before the first frame update
    public void lanceSort()
    {
    }
    public void afficheSort()
    {
        for(int i=0; i < j.sorts.Count; i++)
        {
            GameObject nobj = (GameObject)GameObject.Instantiate(j.sorts[i]);

            nobj.transform.position = new Vector2(30, -(10+i));
            nobj.transform.localScale = new Vector3(1f, 1f, 1f);
            sorts.Add(nobj);
        }
    }
    public void clear()
    {
        foreach(GameObject g in sorts)
        {
            Destroy(g);
        }
    }
}
