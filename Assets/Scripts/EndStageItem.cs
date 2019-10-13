using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStageItem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.GetGameManager.NextLevel();
        }
    }
}
