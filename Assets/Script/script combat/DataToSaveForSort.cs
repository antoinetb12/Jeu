using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class DataToSaveForSort
{
    public string path;
    public int niveau;
    public DataToSaveForSort(Sort sort)
    {
        Debug.Log(sort.nom + ", " + sort.niveau);
        niveau = sort.niveau;
        path= "Sorts/" + sort.gameObject.name;
    }
    
}
