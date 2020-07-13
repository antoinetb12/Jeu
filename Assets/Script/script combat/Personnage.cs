using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public int pdv = 20;
    public float vitesse = 0.1f;
    public int niveau;

    public int pm { get => pm; set => pm = value; }
    public List<Sort> sorts { get => sorts; set => sorts = value; }
    public void initialise(Personnage p)
    {
        this.pdv = p.pdv;
        this.vitesse = p.vitesse;
        this.niveau = p.niveau;
        this.pm = p.pm;
    }
    // Start is called before the first frame update
    protected IEnumerator smoothMovement(Vector3 end)
    {
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
        ControleurCombat.instance.finDeplacement();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
