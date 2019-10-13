using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineButton : MonoBehaviour
{
    [SerializeField] SurfaceEffector2D[] Belts;
    [SerializeField] Sprite on;
    [SerializeField] Sprite off;
    [SerializeField] SpriteRenderer renderer;
    public bool active;

    private void Start()
    {
        setSprites();
    }

    private void setSprites()
    {
         if (active)
        {
            renderer.sprite = on;
        } else
        {
            renderer.sprite = off;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().SetMachine(true, this);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().SetMachine(false, null);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Toggle()
    {
        active = !active;
        foreach (SurfaceEffector2D surfaceEffector in Belts)
        {
            surfaceEffector.enabled = active;
        }
        setSprites();
    }
}
