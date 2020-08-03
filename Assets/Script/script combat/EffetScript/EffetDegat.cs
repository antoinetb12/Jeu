using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetDegat : Effet
{
    public int pdd;

    public EffetDegat(StyleEffect styleEffect, TimeEffect timeEffect, int duree,int pdd) : base(styleEffect, timeEffect, duree)
    {
        this.pdd = pdd;
    }

    public override void applyEffect()
    {
        Victime.recoitAttaque(pdd);
    }

    public override Effet copy()
    {
        return new EffetDegat(styleEffect, timeEffect, duree, pdd);
        //return new EffetDegat();
    }
}
