using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControlleur : MonoBehaviour
{
    public static EffectControlleur instance = null;
    private Transform effectHolder;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        effectHolder = new GameObject("Effect").transform;
    }
    public void ajouteEffetCase(Effet e, Case ca, Personnage lanceur)
    {
        GameObject nobj = (GameObject)GameObject.Instantiate(e.image);
        nobj.transform.position = new Vector3(ca.getX(), -ca.getY(), -2);
        nobj.transform.localScale = new Vector3(1f, 1f, 1f);
        nobj.transform.parent = effectHolder;
        e.addComponent(nobj);
        Effet effet = nobj.GetComponent<Effet>();
        effet.copy(e);
        ca.Effet.Add(effet);
        effet.C = ca;
        effet.Lanceur = lanceur;
        lanceur.effetLance.Add(effet);
        effet.InstanceImage = nobj;
        
    }
    public void ajouteEffetJoueur(Effet e, Case ca, Personnage lanceur)
    {
        GameObject nobj = (GameObject)GameObject.Instantiate(e.image);
        nobj.transform.position = new Vector3(ca.getX(), -ca.getY(), -2);
        nobj.transform.localScale = new Vector3(1f, 1f, 1f);
        nobj.transform.parent = ca.perso.gameObject.transform;
        e.addComponent(nobj);
        Effet effet = nobj.GetComponent<Effet>();
        effet.copy(e);
        effet.InstanceImage = nobj;
        effet.Victime = ca.perso;
        effet.Lanceur = lanceur;
        ca.perso.effetsRecu.Add(effet);
        lanceur.effetLance.Add(effet);
        if (effet.timeEffect == TimeEffect.Constant)
        {
            effet.applyEffect();
        }
            
        
    }
    public List<Effet> getEffets(List<Effet> effects, StyleEffect styleEffect)
    {
        List<Effet> effets = new List<Effet>();
        foreach (Effet e in effects)
        {
           
            if (e.styleEffect == styleEffect)
            {
                effets.Add(e);
            }
        }
        return effets;
    }
    public List<Effet> getEffets(List<Effet> effects, TimeEffect timeEffect)
    {
        List<Effet> effets = new List<Effet>();
        foreach (Effet e in effects)
        {
            if (e.timeEffect == timeEffect)
            {
                effets.Add(e);
            }
        }
        return effets;
    }
    public void applyEffectDebut(Personnage p)
    {
        foreach (Effet f in getEffets(p.effetsRecu, TimeEffect.Debut))
        {
            f.applyEffect();
        }
        Effet e;
        for (int i = 0; i < p.effetLance.Count; i++)
        {
            e = p.effetLance[i];
            e.TourInstancie++;
            if (e.TourInstancie == e.duree)
            {
                if (e.Victime != null)
                {
                    e.Victime.effetsRecu.Remove(e);
                    e.cancelEffect();
                }
                if (e.styleEffect == StyleEffect.Case)
                {
                    e.C.Effet.Remove(e);
                    Destroy(e.InstanceImage);

                }
                p.effetLance.Remove(e);
                i--;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
