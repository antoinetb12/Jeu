using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmplacementPath
{
    public Vector2 position;
    public Vector2 direction;
    public EmplacementPath(Vector2 position, Vector2 direction)
    {
        this.position = position;
        this.direction = direction;
    }
}
