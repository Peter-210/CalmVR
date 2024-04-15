using UnityEngine;

public class LoopAudio : MonoBehaviour
{
    public new AudioSource audio;
    void Start()
    {
        audio.loop = true;
        audio.Play();
    }
}