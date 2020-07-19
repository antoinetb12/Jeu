using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position
{
    public int posX;
    public int posY;
    public int distance;
    public Case precedent;
    public Position(int posX, int posY, int distance, Case precedent)
    {
        this.posX = posX;
        this.posY = posY;
        this.distance = distance;
        this.precedent = precedent;
    }
}
