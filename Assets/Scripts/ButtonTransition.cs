using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ButtonTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 NormalColor = Color.white;
    public Color32 HoverColor = Color.grey;
    public Color32 DownColor = Color.white;

    public new AudioSource audio;
    public AudioSource backgroundAudio;

    private Image Img = null;

    private void Awake()
    {
        Img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Img.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Img.color = NormalColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {        
        Img.color = DownColor;

        audio.Play();

        
       // audio.Play();
       // IEnumerator fadeSound = AudioFadeOut.FadeOut(backgroundAudio, 0.5f);
       // StartCoroutine(fadeSound);
       // StopCoroutine(fadeSound);

       IEnumerator backgroundFade = FadeInOut.FadeTransition();
        StartCoroutine(backgroundFade);
       






        //  StartCoroutine(backgroundFade);
        //background fade out

    }

    public void OnPointerUp(PointerEventData eventData)
    {
  
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
