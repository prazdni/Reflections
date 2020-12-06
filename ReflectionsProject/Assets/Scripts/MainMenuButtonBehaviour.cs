using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image[] _borders;
    [SerializeField] private MainMenuButtonEffect _buttonBehaviour;
    [SerializeField] private AudioSource _audioSource;
    private Button _button;
    private Color _textColorOnDisabled;
    private Color _textColorOnEnabled;
    private TMP_Text _text;
    private void OnEnable()
    {
        Time.timeScale = 1.0f;
        if (_buttonBehaviour == MainMenuButtonEffect.ContinueGame)
        {
            int level = PlayerPrefs.GetInt("maxLevel");
            
            if (level <= 1)
            {
                gameObject.SetActive(false);
            }
        }
        
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
    }

    private void Task()
    {
        _audioSource.Play();
        switch (_buttonBehaviour)
        {
            case MainMenuButtonEffect.None:
                break;
            case MainMenuButtonEffect.ContinueGame:
                SceneManager.LoadScene(PlayerPrefs.GetInt("maxLevel"));
                break;
            case MainMenuButtonEffect.NewGame:
                SceneManager.LoadScene(1);
                break;
            case MainMenuButtonEffect.Credits:
                break;
            case MainMenuButtonEffect.Back:
                break;
            case MainMenuButtonEffect.QuitGame:
                Application.Quit();
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
    
    public enum MainMenuButtonEffect
    {
        None = 0,
        ContinueGame = 1,
        NewGame = 2,
        Credits =3,
        Back = 4,
        QuitGame = 5
    }
}
