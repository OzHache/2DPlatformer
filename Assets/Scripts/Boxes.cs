using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{

    public LayerMask layerToIgnore;
    Collider2D collider;
    Vector3 startingPos;
    Rigidbody2D rb;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        startingPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(LayerMask.LayerToName(layerToIgnore));
        Debug.Log(LayerMask.LayerToName(collision.collider.gameObject.layer));
        if (collision.gameObject.layer == layerToIgnore)
        {
            Physics2D.IgnoreCollision(collision.collider, collider); 
        }
    }

    public void ReturnBox()
    {
        transform.position = startingPos;
        rb.velocity = Vector3.zero;

    }
}
