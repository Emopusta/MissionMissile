using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Shortcuts : MonoBehaviour
{
    Collider col;
    private void Start()
    {
        col = GetComponent<Collider>();
        
    }

    void Update()
    {
        
        //RestartLevel();
        //LoadNextLevelCheatCode();
        //DisableColliderCheatCode();
    }

    void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKey(KeyCode.R))
        {
            
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
    void LoadNextLevelCheatCode()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            int totalNumberOfLevels = SceneManager.sceneCountInBuildSettings;
            if (nextSceneIndex == totalNumberOfLevels)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    void DisableColliderCheatCode()
    {
        if (Input.GetKey(KeyCode.C))
        {
            col.GetComponent<Collider>().enabled = false;
        }
    }
}
