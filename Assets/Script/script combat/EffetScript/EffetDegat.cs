using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetDegat : Effet
{
    public int pdd;
    public TypeSort typeSort;

    public override void addComponent(GameObject g)
    {
        g.AddComponent<EffetDegat>();
    }

    public override void applyEffect()
    {
        applyEffect(Victime);
    }

    public override void applyEffect(Personnage victime)
    {
        int degatPresume = AlgoCalculDegat.degatPresume(Lanceur, typeSort, pdd);
        int degatRecu = AlgoCalculDegat.calculDegat(victime, typeSort, degatPresume);
        victime.recoitAttaque(degatRecu);
    }

    public override void cancelEffect()
    {
    }

    public override void cancelEffect(Personnage victime)
    {
    }

    public override void copy(Effet ef)
    {
        EffetDegat e = (EffetDegat)ef;
        styleEffect = e.styleEffect;
        timeEffect = e.timeEffect;
        duree = e.duree;
        image = e.image;
        pdd=e.pdd;
        //return new EffetDegat();
    }
}
