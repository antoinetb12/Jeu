using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireControlleur : MonoBehaviour
{
    public static InventaireControlleur instance;
    public List<Item> inventaire;
    public List<ItemTemplate> itemPossible;
    public List<GameObject> slot;
    public GameObject inventaireGameObject;
    private Item itemSelected;
    public ListPersonnageScript listPersonnageScript;

    public Item ItemSelected { get => itemSelected; set => itemSelected = value; }


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
       inventaire = new List<Item>(slot.Count);
        inventaireGameObject.SetActive(false);
        Item item = getBaseItems("epeeMagique");
        inventaire.Add(item);
        item = getBaseItems("test");
        inventaire.Add(item);
        SaveSystem.SaveInventaire(inventaire);
        foreach (Item i in SaveSystem.LoadInventaire())
        {
            Debug.Log(i.itemName);
            item.toString();
            Debug.Log(((ItemEquipement)i).feu);
        }
    }
    public void setPersonnage(List<Personnage> joueurs)
    {
        listPersonnageScript.setJoueur(joueurs);
    }
    public void LoadInventaire()
    {
        inventaireGameObject.SetActive(true);
    }
    public void closeInventaire()
    {
        inventaireGameObject.SetActive(false);
    }
    public void displayInventaire()
    {
        inventaireGameObject.SetActive(true);
        Image image;
        Text text;
        SlotScript slotScript;
         
        //TODO gestion si inventaire plus grand que la page 1
        for (int i = 0; i < slot.Count; i++)
        {
            if (inventaire[i] != null)
            {
                slotScript = slot[i].GetComponent<SlotScript>();
                slotScript.item = inventaire[i];
                image = slot[i].transform.GetChild(0).GetComponent<Image>();
                image.color = new Color(1, 1, 1, 1);
                image.sprite = inventaire[i].itemSprite;

                text = slot[i].transform.GetChild(1).GetComponent<Text>();
                text.color = new Color(1, 1, 1, 1);
                text.text = inventaire[i].nombreStock.ToString();
            }
        }
    }
    public void removeItem(Item item)
    {
        Item it = inventaire.Find(ite => item.Equals(ite));
        if (it.nombreStock == 1)
        {
            inventaire.Remove(it);
        }
        else
        {
            it.nombreStock--;
        }
        displayInventaire();
    }
    public Item getBaseItems(string name)
    {
        ItemTemplate itemTemplate = itemPossible.Find(item => item.itemName == name);
        switch (itemTemplate.typeObjet)
        {
            case TypeObjet.Equipement:
                ItemsEquipementTemplate itemsEquipement = (ItemsEquipementTemplate)itemTemplate;
                return itemsEquipement.getItem();
        }
        return null;

    }
    public void addItem(Item item)
    {
        Item it = inventaire.Find(ite => item.Equals(ite));
        if (it == null)
        {
            inventaire.Add(item);
        }
        else
        {
            it.nombreStock++;
        }
        displayInventaire();
    }

}
