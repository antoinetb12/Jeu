using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Personnage : MonoBehaviour
{
    public int pdv = 20;
    public float vitesse = 0.1f;
    public int niveau;
    public int pa = 6;
    public int pmOrigine = 3;
    private int pm;
    public List<GameObject> sorts;
    public GameObject damageText;
    public int initiative = 5;

    public void initialise(Personnage p)
    {
        this.pdv = p.pdv;
        this.vitesse = p.vitesse;
        this.niveau = p.niveau;
    }
    public void setPm(int pm)
    {
        this.pm = pm;
    }
    public int getPm()
    {
        return pm;
    }
    /*
     * savoir si c'est un allié ou ennemi 
     */
    public abstract int getStatusPersonnage();
    public virtual void recoitAttaque(Sort s)
    {
        
        GameObject currentText = Instantiate(damageText);

        currentText.transform.parent = transform;
        currentText.transform.localPosition = damageText.transform.localPosition;
        if (s == null)
        {
            currentText.GetComponent<Text>().text = "-" + 50;

        }
        else
        currentText.GetComponent<Text>().text ="-"+ s.pdd;
        Destroy(currentText, 1.2f);


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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
