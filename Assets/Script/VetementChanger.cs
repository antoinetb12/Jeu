using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VetementChanger : MonoBehaviour
{
    public SpriteRenderer bodyPart;
    public SpriteRenderer bodyPart2;
    public List<Sprite> sprites = new List<Sprite>();
    public List<Sprite> sprites2 = new List<Sprite>();

    private int CurrentOption = 0;

    public void NextSkin()
    {
        CurrentOption++;
        if (CurrentOption >= sprites.Count)
        {
            CurrentOption = 0;
        }
        bodyPart.sprite = sprites[CurrentOption];
        if (bodyPart2 != null)
        {
            bodyPart2.sprite = sprites2[CurrentOption];

        }
    }
    public void PreviousSkin()
    {
        CurrentOption--;
        if (CurrentOption <= 0)
        {
            CurrentOption = sprites.Count-1;
        }
        bodyPart.sprite = sprites[CurrentOption];
        if (bodyPart2 != null)
        {
            bodyPart2.sprite = sprites2[CurrentOption];

        }
    }
}
