using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    public List<Niveau> niveauConnecte = new List<Niveau>();
    public int id;
    private bool visite = false;
    private bool visible = false;
    private int difficulte=0;
    private int etape = 0;
    private float x;
    private float y;
    private float z;
    public Sprite[] listSprite;

    public bool Visite { get => visite; set => visite = value; }
    public bool Visible { get => visible; set => visible = value; }
    public int Difficulte { get => difficulte; set => setDifficulte(value); }
    public int Etape { get => etape; set => etape = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseEnter()
    {
        if (!Visible)
        {
            //transform.GetComponent<SpriteRenderer>().color = "your new color for clicking effect";
            transform.localScale += new Vector3(10f, 10f, 10f);

        }
    }

    public void setAllValue(int id,bool visite, bool visible, int difficulte, int etape, float x, float y, float z)
    {
        this.id = id;
        this.Visite = visite;
        this.Visible = visible;
        this.Difficulte = difficulte;
        this.Etape = etape;
        transform.position = new Vector3(x, y, z);
    }

    void OnMouseExit()
    {
        if (!Visible)
        {
            transform.localScale -= new Vector3(10f, 10f, 10f);
        }
    }
    private void OnMouseUp()
    {
        CarteService.instance.lanceNiveau(this);
        

    }
    public void setDifficulte(int difficulte)
    {

        GetComponent<SpriteRenderer>().sprite = listSprite[difficulte];
        this.difficulte = difficulte;
        if (difficulte == 0)
        {
            transform.localScale = new Vector3(23, 23, 23);
        }
        else
        {
            transform.localScale = new Vector3(30, 30, 30);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool hasConnexion()
    {
        return niveauConnecte.Count > 0;
    }
    public void addConnection(Niveau niveauProche)
    {
        if (niveauConnecte.Contains(niveauProche))
        {
            return;
        }

        niveauConnecte.Add(niveauProche);
    }
}
