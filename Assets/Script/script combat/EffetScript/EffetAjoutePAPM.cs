using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetAjoutePAPM : Effet
{
    public int pa;
    public int pm;

    public override void applyEffect()
    {
        applyEffect(Victime);

    }

    public override void applyEffect(Personnage victime)
    {
        Debug.Log("pa avant "+victime.paOrigine + ", " + victime.getPa());
        victime.paOrigine += pa;
        victime.pmOrigine += pm;
        victime.setPa(Victime.getPa() + pa);
        victime.setPm(Victime.getPm() + pm);
        Debug.Log("pa apres " + victime.paOrigine + ", " + victime.getPa());

    }

    public override void cancelEffect()
    {
        Victime.paOrigine -= pa;
        Victime.pmOrigine -= pm;
        Victime.setPa(Victime.paOrigine);
        Victime.setPm(Victime.pmOrigine);
    }
    public override void cancelEffect( Personnage victime)
    {
        victime.paOrigine -= pa;
        victime.pmOrigine -= pm;
        victime.setPa(victime.paOrigine);
        victime.setPm(victime.pmOrigine);
    }


    public override void addComponent(GameObject g)
    {
        g.AddComponent<EffetAjoutePAPM>();
    }
    public override void copy(Effet ef)
    {
        EffetAjoutePAPM e = (EffetAjoutePAPM)ef;
        styleEffect = e.styleEffect;
        timeEffect = e.timeEffect;
        duree = e.duree;
        image = e.image;
        pa = e.pa;
        pm = e.pm;
        //return new EffetDegat();
    }
}
