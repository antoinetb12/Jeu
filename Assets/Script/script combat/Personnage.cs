using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Personnage : MonoBehaviour
{
    public string nom;
    public int pdv = 20;
    public float vitesse = 0.1f;
    public int niveau;
    public int paOrigine = 6;
    protected int pa;
    public int pmOrigine = 3;
    protected int pm;
    protected int dommage = 1;
    public int caracteristiqueFeu = 5;
    public int caracteristiqueEau = 5;
    public int caracteristiqueVent = 5;
    public int caracteristiqueTerre = 5;
    public int resistance = 0;
    public List<GameObject> sortsG;
    private List<Sort> sorts = new List<Sort>();
    public GameObject damageText;
    public int initiative = 5;
    public DataToSaveForPlayer dataToSaveForPlayer;
    public List<Effet> effetLance = new List<Effet>();
    public List<Effet> effetsRecu = new List<Effet>();
    protected List<ItemEquipement> equipements=new List<ItemEquipement>();
    protected EquipementControlleur equipementControlleur;

    public List<Sort> Sorts { get => sorts; set => sorts = value; }
    public int Dommage { get => dommage; set => dommage = value; }

    private void Start()
    {
        equipementControlleur = GetComponent<EquipementControlleur>();
        Debug.Log("yolo start");
    }
    public void DisplayEquipement()
    {
        Debug.Log(equipementControlleur);
        EquipementSlotControlleur.instance.Display(equipements, this, equipementControlleur);
    }
    public void removeItem(ItemEquipement item)
    {
        equipements.Remove(item);
        DisplayEquipement();
    }
    public void addItem(ItemEquipement item)
    {
       if(equipements.Find(items => items.typeEquipement == item.typeEquipement) != null)
        {
            throw new System.Exception("euh il y a deja un item de ce type dans l'inv");
        }
        else
        {
            equipements.Add(item);
            DisplayEquipement();
        }
    }
    public void initialise(Personnage p)
    {
        this.pdv = p.pdv;
        this.vitesse = p.vitesse;
        this.niveau = p.niveau;
    }
    public void debutTour()
    {
        this.pm = this.pmOrigine;
        this.pa = this.paOrigine;
        foreach(Sort s in Sorts)
        {
            if (s.tourAvantUtilisation > 0)
            {
                Debug.Log(s.name + " , " + s.tourAvantUtilisation);
                s.tourAvantUtilisation--;
            }
        }
    }
    public void setPm(int pm)
    {
        this.pm = pm;
    }
    public int getPm()
    {
        return pm;
    }
    public void setPa(int pa)
    {
        this.pa = pa;
    }
    public int getPa()
    {
        return pa;
    }
    public bool lanceSort(Sort s)
    {
        if (s.cout <= pa)
        {
            pa = pa - s.cout;
            s.tourAvantUtilisation = s.cooldown;
            return true;

        }
        return false;
    }
    public void loadPlayer()
    {
        Debug.Log("essaie de load depuis perso");
        DataToSaveForPlayer data = SaveSystem.LoadPlayer(this.nom);
        if (data != null)
        {
            pdv = data.pdv;
            niveau = data.niveau;
            Debug.Log("il y a tant de sort : "+data.sortsPath.Count);
            Sorts.Clear();
            foreach(DataToSaveForSort s in data.sortsPath)
            {
                Debug.Log("data to save " + s.niveau);  
                GameObject g = (GameObject)Resources.Load(s.path, typeof(GameObject));
                GameObject sortInstance = Instantiate(g);
                Sort sort= sortInstance.GetComponent<Sort>();
                sort.niveau = s.niveau;
                Debug.Log("sort 1 : " + sort.nom + ", " + sort.niveau);

                Sorts.Add(sort);
                Sort sort2 = sortInstance.GetComponent<Sort>();
                Debug.Log("sort 2 : "+sort2.nom + ", " + sort2.niveau);


            }

        }
        else
        {
            foreach(GameObject g in sortsG)
            {
                GameObject sortInstance = Instantiate(g);
                sorts.Add(sortInstance.GetComponent<Sort>());

            }
        }
        
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    /*
     * savoir si c'est un allié ou ennemi 
     */
    public abstract int getStatusPersonnage();
    public virtual void recoitAttaque(int degat)
    {
        
        GameObject currentText = Instantiate(damageText);

        currentText.transform.SetParent(transform);
        currentText.transform.localPosition = damageText.transform.localPosition;
        currentText.GetComponent<Text>().text ="-"+ degat;
        Destroy(currentText, 1.2f);


    }
    public Sort getSort(Sort s)
    {
        foreach(Sort so in Sorts)
        {
            if (so.nom == s.nom)
            {
                return so;
            }
        }
        return null;
    }
    public void afficheSort()
    {
        foreach(Sort s in Sorts)
        {
            Debug.Log("affichage : " + s.nom + ", " + s.niveau);
        }
    }
    public abstract void finMouvement();
    // Start is called before the first frame update
    protected IEnumerator smoothMovement(List<Case> chemin)
    {
        Vector3 positionDebut =new Vector3( transform.position.x,transform.position.y);
         //c.getY() = c.y * -1;
        Case c;
       for(int i=0;i<chemin.Count;i++)
        {
            c = chemin[i];
            foreach (Effet e in c.GetEffets())
            {
                e.applyEffect(this);
            }
            Vector3 end = new Vector3(c.getX(), -c.getY());
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            //While that distance is greater than a very small amount (Epsilon, almost zero):
            while (sqrRemainingDistance > float.Epsilon)
            {
                //Find a new position proportionally closer to the end, based on the moveTime
                Vector3 newPostion = Vector3.MoveTowards(transform.position, end, vitesse * Time.deltaTime);
                //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
                //  rb2D.MovePosition(newPostion);
                transform.position = newPostion;
                //Recalculate the remaining distance after moving.
                sqrRemainingDistance = (transform.position - end).sqrMagnitude;
                //Return and loop until sqrRemainingDistance is close enough to zero to end the function
                yield return null;
            }
        }
        ControleurCombat.instance.finDeplacement(positionDebut,transform.position,this);
        this.finMouvement();
    }

}
