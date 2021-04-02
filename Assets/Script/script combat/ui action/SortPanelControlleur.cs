using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortPanelControlleur : MonoBehaviour
{
    public List<GameObject> listSlot;
    private Joueur joueurActif=null;
    // Start is called before the first frame update
    public void desafficheListSort()
    {
        this.gameObject.SetActive(false);
    }
   public void afficheSort(Joueur joueurActif)
    {
        this.gameObject.SetActive(true);
        this.joueurActif = joueurActif;
        Image image;
        SlotSortScript slotSortScript;
        for (int i = 0; i < ((joueurActif.Sorts.Count <= listSlot.Count)? joueurActif.Sorts.Count:listSlot.Count); i++)
        {
            slotSortScript = listSlot[i].GetComponent<SlotSortScript>();
            slotSortScript.sort = joueurActif.Sorts[i];
            if (!joueurActif.Sorts[i].disponible())
            {
                listSlot[i].GetComponent<Image>().color = Color.red;
                image = listSlot[i].transform.GetChild(0).GetComponent<Image>();
                image.color = new Color(125, 125, 125, 1);
            }
            else
            {
                image = listSlot[i].transform.GetChild(0).GetComponent<Image>();
                image.color = new Color(1, 1, 1, 1);
                listSlot[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            
            image.sprite = joueurActif.Sorts[i].sprite;
        }
    }
    public void UpdateAffichage()
    {
        if (joueurActif != null)
        {
            Image image;
            for (int i = 0; i < ((joueurActif.Sorts.Count <= listSlot.Count) ? joueurActif.Sorts.Count : listSlot.Count); i++)
            {
                {
                    if (!joueurActif.Sorts[i].disponible())
                    {
                        listSlot[i].GetComponent<Image>().color = Color.red;
                        image = listSlot[i].transform.GetChild(0).GetComponent<Image>();
                        image.color = new Color(125, 125, 125, 1);
                        /*GetComponent<Renderer>().material.color = Color.red;*/
                    }
                }
            }
        }
    }
}
