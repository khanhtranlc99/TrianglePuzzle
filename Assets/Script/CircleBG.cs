using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBG : MonoBehaviour
{
    public bool isFill;
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        if (this.gameObject.GetComponent<CircleCollider2D>().enabled == false)
        {
            isFill = true;
        }
        else
        {
            isFill = false;
        }
    }
    
    public void HandleReset()
    {
        spriteRenderer.sprite = sprite;
    }    
  
}
