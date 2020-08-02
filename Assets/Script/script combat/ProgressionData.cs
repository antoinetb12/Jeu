using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ProgressionData
{
    public List<string> personnages;
    public int niveauAtteint;
    public ProgressionData(List<string> personnages, int niveauAtteint)
    {
        this.personnages = personnages;
        this.niveauAtteint = niveauAtteint;
    }
}
