using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    int firstLevel = 1;
    public void RestartGame()
    {
        LoadFirstScene();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        LoadFirstScene();
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(firstLevel);
    }
}
