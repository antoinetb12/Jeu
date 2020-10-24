using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRenderFollow : MonoBehaviour
{
    public Personnage personnageToFollow { get; set; }
    private void LateUpdate()
    {
        if (personnageToFollow != null)
        {
            Vector3 vec = new Vector3(personnageToFollow.transform.position.x, personnageToFollow.transform.position.y, -10);
            transform.position = vec;
        }
    }
}
