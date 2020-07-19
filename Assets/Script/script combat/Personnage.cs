using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Personnage : MonoBehaviour
{
    public int pdv = 20;
    public float vitesse = 0.1f;
    public int niveau;
    public int pa = 6;
    public int pmOrigine = 3;
    private int pm;
    public List<GameObject> sorts;

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
    public abstract void finMouvement();
    // Start is called before the first frame update
    protected IEnumerator smoothMovement(List<Case> chemin)
    {
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
        ControleurCombat.instance.finDeplacement();
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
