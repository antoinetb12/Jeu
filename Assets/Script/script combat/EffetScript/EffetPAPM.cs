using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetPAPM : Effet
{
    public int pa;
    public int pm;

    public override void applyEffect()
    {
        Victime.setPa(Victime.getPa()-pa);
        Victime.setPm(Victime.getPm() - pm);

    }

    public override void applyEffect(Personnage victime)
    {
        victime.setPa(Victime.getPa() - pa);
        victime.setPm(Victime.getPm() - pm);
    }

    public override void cancelEffect()
    {
    }

    public override void cancelEffect(Personnage victime)
    {
    }
    public override void addComponent(GameObject g)
    {
        g.AddComponent<EffetPAPM>();
    }
    public override void copy(Effet ef)
    {
        EffetPAPM e = (EffetPAPM)ef;
        styleEffect = e.styleEffect;
        timeEffect = e.timeEffect;
        duree = e.duree;
        image = e.image;
        pa = e.pa;
        pm = e.pm;
        //return new EffetDegat();
    }
}
