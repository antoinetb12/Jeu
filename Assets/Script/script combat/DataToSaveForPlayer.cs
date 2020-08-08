using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class DataToSaveForPlayer
{
    public int pdv;
    public int niveau;
    public List<DataToSaveForSort> sortsPath;
    public DataToSaveForPlayer(Personnage personnages)
    {
        pdv = personnages.pdv;
        niveau = personnages.niveau;
        sortsPath = new List<DataToSaveForSort>();
        foreach(Sort s in personnages.Sorts)

        {
            Debug.Log("save niveau : " + s.niveau);
            sortsPath.Add(new DataToSaveForSort(s));
        }
    }
    
}
