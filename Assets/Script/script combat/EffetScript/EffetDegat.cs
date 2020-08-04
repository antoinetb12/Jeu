using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetDegat : Effet
{
    public int pdd;

    public EffetDegat(StyleEffect styleEffect, TimeEffect timeEffect, int duree,GameObject image,int pdd) : base(styleEffect, timeEffect, duree,image)
    {
        this.pdd = pdd;
    }

    public override void applyEffect()
    {
        Victime.recoitAttaque(pdd);
    }

    public override void applyEffect(Personnage victime)
    {
        victime.recoitAttaque(pdd);
    }

    public override Effet copy()
    {
        return new EffetDegat(styleEffect, timeEffect, duree, image,pdd);
        //return new EffetDegat();
    }
}
