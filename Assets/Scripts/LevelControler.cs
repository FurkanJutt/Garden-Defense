using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControler : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;
    [SerializeField] AudioClip winSound;

    int numberOfAttackers;
    bool timeEnded = false;

    HPDisplay hpDisplay;
    GameTimer gameTimer;
    StarsDisplay starsDisplay;
    RemainingStars remainingStarsClass;

    private void Awake()
    {
        hpDisplay = FindObjectOfType<HPDisplay>();
        gameTimer = FindObjectOfType<GameTimer>();
        starsDisplay = FindObjectOfType<StarsDisplay>();
        remainingStarsClass = FindObjectOfType<RemainingStars>();
        SetLevelDifficulty();
    }

    private void Start()
    {
        Time.timeScale = 1;
        winText.SetActive(false);
        loseText.SetActive(false);
        //hpDisplay = FindObjectOfType<HPDisplay>();
        //gameTimer = FindObjectOfType<GameTimer>();
        //starsDisplay = FindObjectOfType<StarsDisplay>();
        //remainingStarsClass = FindObjectOfType<RemainingStars>();
        //SetLevelDifficulty();
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && timeEnded)
        {
            StartCoroutine(HandleWin());
            Time.timeScale = 0;
        }
    }

    private IEnumerator HandleWin()
    {
        winText.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
        int stars = starsDisplay.GetStars();
        remainingStarsClass.SetRemainingStars(stars);
        Debug.Log("HandleWin :" + remainingStarsClass.GetRemainingStars());
        if (SceneManager.GetActiveScene().name != "Level 5")
        {
            yield return new WaitForSecondsRealtime(3f);
            FindObjectOfType<LevelSystem>().LoadNextScene();
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            yield return new WaitForSecondsRealtime(3f);
            FindObjectOfType<LevelSystem>().LoadStartMenu();
        }
    }

    public void HandleLost()
    {
        Time.timeScale = 0;
        loseText.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
    }

    public void LevelTimerEnded()
    {
        timeEnded = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawn();
        }
    }

    private void SetLevelDifficulty()
    {
        float difficulty = PlayerPerfControler.GetDifficulty();
        int starsRemain = remainingStarsClass.GetRemainingStars();
        Debug.Log("Awake() :" + starsRemain);
        if (difficulty == 0)
        {
            hpDisplay.SetHP(20);
            gameTimer.SetLevelTime(60f);
            starsDisplay.SetStartingStars(500 + starsRemain);
        }
        else if (difficulty == 1)
        {
            hpDisplay.SetHP(10);
            gameTimer.SetLevelTime(30f);
            starsDisplay.SetStartingStars(350 + starsRemain);
        }
        else if (difficulty == 2)
        {
            hpDisplay.SetHP(5);
            gameTimer.SetLevelTime(1f);
            starsDisplay.SetStartingStars(220 + starsRemain);
        }
    }
}
