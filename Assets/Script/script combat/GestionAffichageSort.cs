using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionAffichageSort :MonoBehaviour
{
    public Joueur j;
    private Dictionary<Sort,GameObject> sorts=new Dictionary<Sort,GameObject>();
    // Start is called before the first frame update
    public void lanceSort()
    {
    }
    public void afficheSort()
    {
       GameObject g=GameObject.Find("listeSort");

        for (int i=0; i < j.Sorts.Count; i++)
        {
            
            GameObject nobj = (GameObject)GameObject.Instantiate(j.Sorts[i].gameObject);

            nobj.transform.position = new Vector2(30, -(10+i));
            nobj.transform.localScale = new Vector3(1f, 1f, 1f);
            nobj.transform.SetParent(g.transform,false);
            sorts.Add(j.Sorts[i],nobj);
            j.Sorts[i].Detenteur = j;
            if (!j.Sorts[i].disponible())
            {
                nobj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
    public void UpdateAffichage()
    {
        if (j != null &&  sorts.Count!=0) { 
            foreach(Sort s in j.Sorts)
            {
                Debug.Log(s.name + "");
                if (!s.disponible())
                {
                    sorts[s].GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
    }
    public void clear()
    {
        foreach(GameObject g in sorts.Values)
        {
            Destroy(g);
        }
        sorts.Clear();
    }
}
