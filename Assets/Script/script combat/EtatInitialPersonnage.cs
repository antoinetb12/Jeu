using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatInitialPersonnage
{
    public int pm;
    public int pa;
    public int dommage = 1;
    public int caracteristiqueFeu = 5;
    public int caracteristiqueEau = 5;
    public int caracteristiqueVent = 5;
    public int caracteristiqueTerre = 5;
    public int resistanceBase = 0;
    public void initEtat(Personnage p) 
    {
        pm = p.pmOrigine;
        pa = p.paOrigine;
        dommage = p.Dommage;
        caracteristiqueFeu = p.caracteristiqueFeu;
        caracteristiqueEau = p.caracteristiqueEau;
        caracteristiqueVent = p.caracteristiqueVent;
        caracteristiqueTerre = p.caracteristiqueTerre;
        resistanceBase = p.resistance;
    }
}
