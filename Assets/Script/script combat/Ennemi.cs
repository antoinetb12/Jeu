﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Personnage
{
    private AlgoDeplacement algo;
    public List<Joueur> joueurs;
    private Case[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        algo = GetComponent<AlgoDeplacement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void joue(Case[,] grid, int dimX, int dimY)
    {
        this.grid = grid;
        List<Case> cheminChoisi=null;
        Joueur jChoisi=null;
        List<Case> chemin;
        foreach (Joueur j in joueurs)
        {
            if (j.pdv > 0)
            {
                chemin = algo.FindPath(transform.position, j.transform.position, grid, dimX, dimY);
            }
            else
            {
                chemin = null;
            }
            if (cheminChoisi == null)
            {
                cheminChoisi = chemin;
                jChoisi = j;
            }
            else if(chemin!=null)
            {
                if (cheminChoisi.Count - 1 <= getPm() && chemin.Count-1 <= getPm())
                {
                    if (jChoisi.pdv > j.pdv)
                    {
                        cheminChoisi = chemin;
                        jChoisi = j;
                    }
                }
                else if(cheminChoisi.Count>chemin.Count)
                {
                    cheminChoisi = chemin;
                    jChoisi = j;
                }
            }
            
        }
        chemin.Count-1 > getPm()


        chemin.RemoveAt(chemin.Count - 1);
        while (chemin.Count > getPm())
        {
            chemin.RemoveAt(chemin.Count - 1);
        }
        
        StartCoroutine(smoothMovement(chemin));
    }
    int GetDistance(Case nodeA, Case nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());

        if (dstX > dstY)
            return dstY + (dstX - dstY);
        return dstX +(dstY - dstX);
    }

    public override void finMouvement()
    {
        Case startNode = grid[Mathf.RoundToInt(-transform.position.y), Mathf.RoundToInt(transform.position.x)];
        Case targetNode = grid[Mathf.RoundToInt(-joueurs[0].transform.position.y), Mathf.RoundToInt(joueurs[0].transform.position.x)];
        Sort s = sorts[0].GetComponent<Sort>();
        if ( GetDistance(startNode, targetNode) <= s.range)
        {
            GetComponent<Animator>().SetTrigger("attaque1");
            joueurs[0].recoitAttaque(s.pdd);
        }
    }
}