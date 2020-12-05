using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishDetector : MonoBehaviour
{
    public delegate void PlayerReachedFinishEventHandler(bool reached);
    public static PlayerReachedFinishEventHandler PlayerReachedFinishEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerReachedFinishEvent?.Invoke(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerReachedFinishEvent?.Invoke(false);
        }
    }
}
