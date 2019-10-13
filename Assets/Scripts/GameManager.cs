using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] LevelManager[] levels;
    [SerializeField] GameObject GameOverScreen;
    public int currentLevel = -1;
    public static GameManager GetGameManager;
    

    private void Start()
    {
        GetGameManager = this;
        NextLevel();
        //move player to current level
        
    }

    public void NextLevel()
    {
        currentLevel++;
        if (levels.Length >= currentLevel+1 ){
            levels[currentLevel].gameObject.SetActive(true);
            player.gameObject.transform.position = levels[currentLevel].playerPos;
            player.startingLocation = levels[currentLevel].playerPos;
            Camera.main.transform.position = levels[currentLevel].cameraPos;
        }
        else
        {
            GameOverScreen.SetActive(true);
            player.enabled = false;
        }
        if(currentLevel-1 >= 0)
        {
            levels[currentLevel - 1].gameObject.SetActive(false);
        }
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
