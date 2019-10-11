using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] string ImpactMessage;
    private Collider2D collider;
    public Tool NeededTool;
    // Start is called before the first frame update
    void Awake()
    {
        collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Hurt(ImpactMessage, NeededTool);
        }
    }
}
