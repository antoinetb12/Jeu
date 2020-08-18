using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoCalculDegat 
{
    // Start is called before the first frame update
    public static int degatPresume(Personnage lanceur, Sort s)
    {
        int degat = s.pdd + lanceur.Dommage;
        switch (s.typeSort)
        {
            case TypeSort.feu: degat +=  lanceur.caracteristiqueFeu ;
                break;
            case TypeSort.eau:
                degat += lanceur.caracteristiqueEau;
                break;
            case TypeSort.vent:
                degat += lanceur.caracteristiqueVent;
                break;
            case TypeSort.terre:
                degat += lanceur.caracteristiqueTerre;
                break;
        }
        return degat;
    }
    public static int degatPresume(Personnage lanceur, TypeSort type, int pdd)
    {
        Debug.Log("lanceur : " + lanceur);
        int degat = pdd + lanceur.Dommage;
        switch (type)
        {
            case TypeSort.feu:
                degat += lanceur.caracteristiqueFeu;
                break;
            case TypeSort.eau:
                degat += lanceur.caracteristiqueEau;
                break;
            case TypeSort.vent:
                degat += lanceur.caracteristiqueVent;
                break;
            case TypeSort.terre:
                degat += lanceur.caracteristiqueTerre;
                break;
        }
        return degat;
    }
    public static int calculDegat(Personnage victime, TypeSort type,int pddPresume)
    {
        Debug.Log(victime);
        Debug.Log(victime.caracteristiqueFeu);
        float degat = pddPresume;
        switch (type)
        {
            case TypeSort.feu:
                degat -= (degat/100)*(victime.caracteristiqueFeu/5);
                break;
            case TypeSort.eau:
                degat -= (degat / 100) * (victime.caracteristiqueEau/5);
                break;
            case TypeSort.vent:
                degat -= (degat / 100) * (victime.caracteristiqueVent/5);
                break;
            case TypeSort.terre:
                degat -= (degat / 100) * (victime.caracteristiqueTerre/5);
                break;
        
    }
        degat -= (degat / 100) * victime.resistance;
        return Mathf.RoundToInt(degat);
    }
    

    
}
