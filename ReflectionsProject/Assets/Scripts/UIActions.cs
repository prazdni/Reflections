using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIActions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _border;
    private TMP_Text _text;
    private void Start()
    {
        _border.fillAmount = 0.0f;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Task);
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void Task()
    { 
        Debug.Log("Cliecked!");
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
