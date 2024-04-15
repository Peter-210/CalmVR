using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{

    private static bool fadeIn, fadeOut = false;

    private static float fadeTime = 0.01f; //change this
    private Renderer rend;

    private static int currentScene = 0;
    private static string[] scenes = { "Env1", "Env2", "Env3" };
    public static GameObject currentObj;
    private int timePassed = 0;



    public static void nextScene()
    {

        int nextScene = currentScene++;
        if (nextScene >= scenes.Length)
        {
            nextScene = 0;
        }

        currentScene = nextScene;
        SceneManager.LoadScene(scenes[currentScene]);
    }




    public static IEnumerator FadeIn()
    {
        Color c = currentObj.GetComponent<Renderer>().material.color;

        float alpha = 0;
        while (alpha < 1)
        {
            alpha+= 0.1f;
            c.a = alpha;
            currentObj.GetComponent<Renderer>().material.SetColor("_Color", c);
            yield return null;
        }
    }



    public static IEnumerator FadeTransition()
    {
        Color c = currentObj.GetComponent<Renderer>().material.color;

        float alpha = 0;
        while (alpha < 1)
        {
            alpha+= 0.1f;
            c.a = alpha;
            currentObj.GetComponent<Renderer>().material.SetColor("_Color", c);
            yield return null;
        }
        
        int delay = 0;
        while (delay < 20)
        {
            delay++;
            yield return null;
        }
        
        nextScene();
    }



    public static IEnumerator FadeOut()
    {
        
        Color c = currentObj.GetComponent<Renderer>().material.color;
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= 0.1f;
            c.a = alpha;
            currentObj.GetComponent<Renderer>().material.SetColor("_Color",c);
            yield return null;
        }
    }


    
    




    /*
     *
     * public static class AudioFadeOut {

public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
    float startVolume = audioSource.volume;

    while (audioSource.volume > 0) {
        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

        yield return null;
    }

    audioSource.Stop ();
    audioSource.volume = startVolume;
}

}
     */







    // private void fadeInTransition()
    // {
    //     
    //     Material mat = currentObj.GetComponent<Renderer>().material;
    //     float curAlpha = mat.color.a;
    //     float nextAlpha = (float)Math.Max(curAlpha + 0.001, 1);
    //     
    //     changeAlpha(mat, nextAlpha);
    //     if (nextAlpha >= 1)
    //     {
    //         fadeIn = false;
    //     }
    //     
    // }



    public static void startFadeOutTransition()
    {
        fadeOut = true;
        fadeIn = false;
    }
    

    // private void fadeOutTransition()
    // {
    //     
    //     Material mat = currentObj.GetComponent<Renderer>().material;
    //     float curAlpha = mat.color.a;
    //     float nextAlpha = (float)Math.Max(curAlpha - 0.00001, 0);
    //     
    //     changeAlpha(mat, nextAlpha);
    //     if (nextAlpha <= 0)
    //     {
    //         fadeOut = false;
    //         nextScene();
    //
    //         fadeIn = true;
    //     }
    // }


    //
    // private static void changeAlpha(Material mat, float newAlpha)
    // {
    //     Color color = mat.color;
    //     Color nextColor = new Color(color.r, color.g, color.b, newAlpha);
    //     mat.SetColor("_Color", nextColor);
    //     
    // }


    private void Awake()
    {
        GameObject obj = GameObject.Find("[CameraRig]/Camera/Fader");
        currentObj = obj;
        DontDestroyOnLoad(obj);



    }


    // Start is called before the first frame update
    void Start()
    {
        IEnumerator start = FadeOut();
        StartCoroutine(start);
    }

    // Update is called once per frame
    void Update()
    {
    
        //
        // if (fadeIn)
        // {
        //     Debug.Log("Ping - "+fadeIn);
        //     fadeInTransition();
        // }
        // else if (fadeOut)
        //     fadeOutTransition();
    }


}
