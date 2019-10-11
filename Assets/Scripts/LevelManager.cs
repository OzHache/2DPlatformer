using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform PlayerStartingPos;
    public Vector3 playerPos { get { return PlayerStartingPos.position; } }
    public Vector3 cameraPos { get { return transform.position + (Vector3.forward * -10f); } }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

}
