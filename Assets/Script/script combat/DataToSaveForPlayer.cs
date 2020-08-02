using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class DataToSaveForPlayer
{
    public int pdv;
    public int niveau;
    public List<string> sortsPath;
    public DataToSaveForPlayer(Personnage personnages)
    {
        pdv = personnages.pdv;
        niveau = personnages.niveau;
        sortsPath = new List<string>();
        foreach(GameObject g in personnages.sorts)
        {
            sortsPath.Add("Sorts/"+g.name);
        }
    }
    
}
