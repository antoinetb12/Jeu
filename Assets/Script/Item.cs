using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Item 
{
    public string itemName;
    [System.NonSerialized()]
    public Sprite itemSprite;
    public TypeObjet typeObjet;
    public int nombreStock;
    public string description;

    public Item(string itemName, Sprite itemSprite, TypeObjet typeObjet,string description)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.typeObjet = typeObjet;
        this.description = description;
        nombreStock = 1;
    }

    public virtual bool Equals(Item obj)
    {
        return obj is Item item &&
               itemName == item.itemName &&
               EqualityComparer<Sprite>.Default.Equals(itemSprite, item.itemSprite) &&
               typeObjet == item.typeObjet &&
               description==item.description;
    }

    public override int GetHashCode()
    {
        var hashCode = -1024444936;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(itemName);
        hashCode = hashCode * -1521134295 + EqualityComparer<Sprite>.Default.GetHashCode(itemSprite);
        hashCode = hashCode * -1521134295 + typeObjet.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
        return hashCode;
    }

    public abstract void toString();
}
