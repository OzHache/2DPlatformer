using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    private Transform[] levelStartingPoints;
    [SerializeField] LevelManager[] levels;
    public int currentLevel = -1;

    private void Start()
    {
        NextLevel();
        //move player to current level
        player.gameObject.transform.position = levelStartingPoints[currentLevel].position;
    }

    public void NextLevel()
    {
        currentLevel++;
        if (levels.Length >= currentLevel) {
            levels[currentLevel].gameObject.SetActive(true);
        }
        if(currentLevel-1 >= 0)
        {
            levels[currentLevel - 1].gameObject.SetActive(false);
        }
    }



}
