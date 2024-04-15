using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PauseAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
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
        AudioListener.pause = true;
        audio.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
