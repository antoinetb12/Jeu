using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    public static void SavePlayer(Personnage j)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/"+j.nom+".fun";
        Debug.Log("save ici : " + path);
        FileStream stream = new FileStream(path, FileMode.Create);
        DataToSaveForPlayer data = new DataToSaveForPlayer(j);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static DataToSaveForPlayer LoadPlayer(string nom)
    {
        string path = Application.persistentDataPath + "/" + nom + ".fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataToSaveForPlayer data = formatter.Deserialize(stream) as DataToSaveForPlayer;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static void SaveInventaire(List<Item> items)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/inventaire.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, items);
        stream.Close();
    }
    public static List<Item> LoadInventaire()
    {
        string path = Application.persistentDataPath + "/inventaire.fun";
        Debug.Log("load ici : " + path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<Item> data = formatter.Deserialize(stream) as List<Item>;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static void SaveProgression(List<string> personnagesNames, int niveauAtteint)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamesInfo.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        ProgressionData data = new ProgressionData(personnagesNames, niveauAtteint);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static ProgressionData LoadProgression()
    {
        string path = Application.persistentDataPath + "/gamesInfo.fun";
        Debug.Log("load ici : " + path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            ProgressionData data = formatter.Deserialize(stream) as ProgressionData;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
    public static void SaveMap(List<NiveauEntity> g)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/map.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(stream, g);
        stream.Close();
    }
    public static List<NiveauEntity> LoadMap()
    {
        string path = Application.persistentDataPath + "/map.fun";
        Debug.Log("load ici : " + path);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<NiveauEntity> data = formatter.Deserialize(stream) as List<NiveauEntity>;
            stream.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

}
