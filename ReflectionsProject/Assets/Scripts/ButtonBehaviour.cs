using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _border;
    private Button _button;
    private TMP_Text _text;
    private AudioSource _audioSource;
    private void Start()
    {
        _border.fillAmount = 0.0f;
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
        _button.onClick.AddListener(Task);
        _text = GetComponentInChildren<TMP_Text>();
        _text.color = Color.gray;
    }

    private void Task()
    { 
        _audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _border.fillAmount = 1.0f;
        _text.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _border.fillAmount = 0.0f;
        _text.color = Color.gray;
    }
}
