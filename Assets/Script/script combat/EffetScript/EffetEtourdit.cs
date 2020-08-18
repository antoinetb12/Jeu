using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffetEtourdit : Effet
{


    public override void applyEffect()
    {
        Victime.setPa(0);
        Victime.setPm(0);

    }
    public override void addComponent(GameObject g)
    {
        g.AddComponent<EffetEtourdit>();
    }
    public override void applyEffect(Personnage victime)
    {
        throw new System.NotImplementedException();
    }

    public override void cancelEffect()
    {
    }

    public override void cancelEffect(Personnage victime)
    {
    }

    public override void copy(Effet ef)
    {
        EffetEtourdit e = (EffetEtourdit)ef;
        styleEffect = e.styleEffect;
        timeEffect = e.timeEffect;
        duree = e.duree;
        image = e.image;
    }
}
