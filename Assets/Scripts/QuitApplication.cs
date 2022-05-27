using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        QuitGame();

    }

    private static void QuitGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Clicked Escape Button.");
            Application.Quit();
        }
    }
}
