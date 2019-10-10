using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBox : MonoBehaviour
{
    public Sprite Smashed;
    public SpriteRenderer ren;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().smash(true, this);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().smash(false, this);
        }
    }

    internal void Trigger()
    {
        if (active)
        {
            active = false;
            ren.sprite = Smashed;
        }
    }
}
