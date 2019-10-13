using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashBox : MonoBehaviour
{
    public Sprite Smashed;
    public SpriteRenderer ren;
    public bool active = true;
    private Collider2D collider;
    [SerializeField] private Tool toolNeeded;
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.tools.Contains(toolNeeded)){
                player.smash(true, this);
            }
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
            collider.enabled = false;
        }
    }
}
