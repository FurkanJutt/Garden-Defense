using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    int currentSceneIndex = 0;

    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (currentSceneIndex == 0)
        {
            yield return new WaitForSeconds(4f);
            LoadStartMenu();
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadGameOver()
    {
        //StartCoroutine(LoadStartMenu(3f));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
