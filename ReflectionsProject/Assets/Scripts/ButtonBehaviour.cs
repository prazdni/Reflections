using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image[] _borders;
    private Button _button;
    private TMP_Text _text;
    private AudioSource _audioSource;
    private Color _textColor;
    private void Awake()
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 0.0f;
        }
        
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();
        _button.onClick.AddListener(Task);
        _text = GetComponentInChildren<TMP_Text>();
        _text.color = new Color(0.6078432f, 0.4509804f, 0.4509804f);
    }

    private void Task()
    { 
        _audioSource.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 1.0f;
        }

        _text.color = new Color(0.4078432f, 0.1176471f, 0.1176471f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var t in _borders)
        {
            t.fillAmount = 0.0f;
        }

        _text.color = new Color(0.6078432f, 0.4509804f, 0.4509804f);
    }
}
