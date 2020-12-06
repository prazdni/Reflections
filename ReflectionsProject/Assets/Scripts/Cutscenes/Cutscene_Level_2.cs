using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimationsController))]
public class Cutscene_Level_2 : MonoBehaviour
{
    private float _speed = 1.5f;

    private Transform _transform;
    private PlayerMovement _playerMovement;
    private PlayerAnimationsController _playerAnimationsController;

    private IEnumerator StartCutscene()
    {
        float time = 3.6f;
        StartCoroutine(_playerMovement.StopMovement(time));
        _playerAnimationsController.PlayStartAnimation(time);
        while (time > 0)
        {
            if (time > 2.1f)
                _transform.position += Vector3.right * Time.deltaTime * _speed;

            time -= Time.deltaTime;

            yield return true;
        }
    }

    private void Start()
    {
        _transform = transform;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimationsController = GetComponent<PlayerAnimationsController>();
        StartCoroutine(StartCutscene());
    }
}
