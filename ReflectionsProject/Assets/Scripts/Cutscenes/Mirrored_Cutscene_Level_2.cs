using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimationsController))]
public class Mirrored_Cutscene_Level_2 : MonoBehaviour
{
    [SerializeField] private Transform _mainPlayer;

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
            _transform.position = new Vector2(_mainPlayer.position.x, _transform.position.y);

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
