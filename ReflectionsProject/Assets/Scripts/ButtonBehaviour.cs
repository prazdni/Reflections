﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image[] _borders;
    [SerializeField] private ButtonEffect _buttonEffect;
    [SerializeField] private AudioSource _audioSource;
    private Button _button;
    private TMP_Text _text;
    private Color _textColorOnDisabled;
    private Color _textColorOnEnabled;
    private Canvas _parentCanvas;
    private void Awake()
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 0.0f;
        }
        
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Task);
        _text = GetComponentInChildren<TMP_Text>();
        
        _textColorOnDisabled = new Color(0.6078432f, 0.4509804f, 0.4509804f);
        _textColorOnEnabled = new Color(0.4078432f, 0.1176471f, 0.1176471f);
        _text.color = _textColorOnDisabled;
        
        _parentCanvas = GetComponentInParent<Canvas>();
    }

    private void Task()
    { 
        _audioSource.Play();
        switch (_buttonEffect)
        {
            case ButtonEffect.None:
                break;
            case ButtonEffect.Resume:
                Time.timeScale = 1.0f;
                _parentCanvas.gameObject.SetActive(false);
                break;
            case ButtonEffect.Quit:
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(0);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 1.0f;
        }

        _text.color = _textColorOnEnabled;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 0.0f;
        }

        _text.color = _textColorOnDisabled;
    }
    
    public enum ButtonEffect
    {
        None = 0,
        Resume = 1,
        Quit = 2
    }
}