using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update

    private int currentScene = 0;
    private string[] scenes = {"Env1", "Env2", "Env3"};
    
    void Start()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test");
    }



    private void nextScene()
    {
        int nextScene = currentScene++;
        if (nextScene >= scenes.Length)
        {
            nextScene = 0;
        }

        currentScene = nextScene;
        SceneManager.LoadScene(scenes[currentScene]);
    }
}
