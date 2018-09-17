using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Brick.breakableCount = 0;
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void loadGameOver()
    {
        SceneManager.LoadScene(8);
    }

    public void loadWinScene()
    {
        SceneManager.LoadScene(7);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            loadNextScene();
        }
    }
}
