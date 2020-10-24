using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipementScript : MonoBehaviour
{
    public Animator animator { get; set; }
    private Animator parentAnimator;
    private SpriteRenderer spriteRenderer;
    private AnimatorOverrideController AnimatorOverrideController;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
        parentAnimator = GetComponentInParent<Animator>();

        animator = GetComponent<Animator>();

        AnimatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        //TODO https://www.youtube.com/watch?v=wyyuYX25tBU&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=84

        animator.runtimeAnimatorController = AnimatorOverrideController;
    }


    public void equip(ItemEquipement item)
    {
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = item.itemSpriteOnPerso;

        AnimatorOverrideController["testT"] = item.animation;
        // https://www.youtube.com/watch?v=wyyuYX25tBU&list=PLX-uZVK_0K_6JEecbu3Y-nVnANJznCzix&index=84
    }
    public void Desequip()
    {
        spriteRenderer.sprite = null;
        AnimatorOverrideController["testT"] = null;

        Color c =spriteRenderer.color;
        c.a = 0;
        spriteRenderer.color = c;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
