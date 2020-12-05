using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonDownEvent;
    [SerializeField] private UnityEvent _buttonUpEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _buttonDownEvent?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _buttonUpEvent?.Invoke();
        }
    }
}
