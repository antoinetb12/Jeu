using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public float vitesse = 0.1f;
    private bool onDeplacement = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void move(Vector3 end)
    {
        if (onDeplacement)
        {
            return;
        }
        print("debut deplacement " + onDeplacement);
        onDeplacement = true;
        StartCoroutine(smoothMovement(end));
        onDeplacement = false;
        Controleur.instance.finDeplacement();
    }

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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
