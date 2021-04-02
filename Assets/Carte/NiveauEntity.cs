using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class NiveauEntity
{
     public List<NiveauEntity> niveauConnecte = new List<NiveauEntity>();
     public int id;
     bool visite = false;
     bool visible = false;
     int difficulte = 0;
     int etape = 0;
     public float x;
     public float y;
     public float z;

    public NiveauEntity(int id,bool visite, bool visible, int difficulte, int etape, float x, float y, float z)
    {
        niveauConnecte = new List<NiveauEntity>();
        this.visite = visite;
        this.visible = visible;
        this.difficulte = difficulte;
        this.etape = etape;
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
    }
    public void setValue(Niveau niveau)
    {
        niveau.setAllValue(id,visite, visible, difficulte, etape, x, y, z);
    }
    public void addConnection(NiveauEntity niveauProche)
    {
        if (niveauConnecte.Contains(niveauProche))
        {
            return;
        }

        niveauConnecte.Add(niveauProche);
    }
}
