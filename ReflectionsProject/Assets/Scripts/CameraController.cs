using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Transform _background;
    private Transform _reflection;
    private Transform _trees;
    private Camera _camera;
    private void Start()
    {
        _background = GameObject.FindGameObjectWithTag("BackGround").transform;
        _reflection = GameObject.FindGameObjectWithTag("Reflection").transform;
        _trees = GameObject.FindGameObjectWithTag("Trees").transform;
        var position = transform.position;
        _background.transform.position = position + Vector3.forward;
        _reflection.transform.position = position + Vector3.forward;
        _trees.transform.position = new Vector3(15.0f -position.x * 0.2f, position.y, position.z) + Vector3.forward;
    }

    private void Update()
    {
        if (_player != null)
        {
            if (_player.position.x > 0.0f && _player.position.x <= 27.0f)
            {

                var position = transform.position;
                position = new Vector3(_player.position.x, position.y, position.z);
                transform.position = position;
                _background.transform.position = position + Vector3.forward;
                _reflection.transform.position = position + Vector3.forward;
                _trees.transform.position = new Vector3(15.0f -position.x * 0.2f, position.y, position.z) + Vector3.forward;
            }
        }
        
        
    }
}
