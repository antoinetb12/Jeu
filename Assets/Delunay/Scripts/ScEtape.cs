using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScEtape : MonoBehaviour
{
    private List<GameObject> EtapeConnecte = new List<GameObject>();
    public int etape=0;
    private float x;
    private float y;
    private float z;
    public ScEtape etapeParent;
    public Niveau niveauParent =null;
    public Niveau niveauAssocie = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public List<GameObject> getConnexion()
    {
        return EtapeConnecte;
    }
    public bool hasConnexion()
    {
        return EtapeConnecte.Count > 0;
    }
    public void addConnection(GameObject etapeProche)
    {
        if (EtapeConnecte.Contains(etapeProche))
        {
            return;
        }

        EtapeConnecte.Add(etapeProche);
    }
}