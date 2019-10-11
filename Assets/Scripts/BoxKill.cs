using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKill : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Boxes>() != null)
        {
            collision.gameObject.GetComponent<Boxes>().ReturnBox();
        }
    }
}
