using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiDrag : MonoBehaviour
{
    float offsetX;
    float offsetY;
    public void beginDrag()
    {
        offsetX = transform.position.x - Input.mousePosition.x;
        offsetY = transform.position.y - Input.mousePosition.y;
        Debug.Log(offsetY);
    }
    public void onDrag()
    {
        transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
        //Debug.Log(offsetY);
    }
}
