using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAffichageSort 
{
    public Joueur j;
    // Start is called before the first frame update
    public void lanceSort()
    {
        Debug.Log(j.pa);
    }
    public void afficheSort()
    {
        for(int i=0; i < j.sorts.Count; i++)
        {
            Debug.Log("afficheSort");
            GameObject nobj = (GameObject)GameObject.Instantiate(j.sorts[i]);

            nobj.transform.position = new Vector2(30, -(10+i));
            nobj.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
