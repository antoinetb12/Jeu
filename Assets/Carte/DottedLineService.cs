using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLineService : MonoBehaviour
{
    // Inspector fields
    public Sprite Dot;
    [Range(0.01f, 30f)]
    public float Size;
    [Range(0.1f, 30f)]
    public float Delta;
    GameObject pathContainer;
    Transform pathHolder = null;
 

        //Utility fields
    List <EmplacementPath> positions = new List<EmplacementPath>();
    List<GameObject> dots = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
 
    }

    private void DestroyAllDots()
    {
        foreach (var dot in dots)
        {
            Destroy(dot);
        }
        dots.Clear();
    }

    GameObject GetOneDot()
    {
        GameObject gameObject = new GameObject("test");
        //gameObject = (GameObject)Instantiate(gameObject);
        gameObject.transform.localScale = Vector3.one * Size;
        gameObject.transform.parent = transform;

        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Dot;
        gameObject.transform.SetParent(pathContainer.transform);
        return gameObject;
    }

    public void DrawDottedLine(Vector2 start, Vector2 end)
    {
        Vector2 point = start;
        Vector2 direction = (end - start).normalized;
        Debug.Log(direction);
        while ((end - start).magnitude > (point - start).magnitude)
        {
            positions.Add(new EmplacementPath(point,direction));
            point += (direction * Delta);
        }

    }

    public void Render()
    {
        pathContainer = GameObject.Find("PathContainer");
        Vector3 v = new Vector3();
        foreach (EmplacementPath position in positions)
        {
            GameObject g = GetOneDot();
            g.transform.position = position.position;

            float zRot = Vector2.Angle(Vector2.up, position.direction);
            if (position.direction.x > 0.0f)
            {
                zRot *= -1.0f;
            }
            g.transform.Rotate(new Vector3(0,0,1), zRot);
            g.name = zRot+"";
            dots.Add(g);
        }
    }
}

