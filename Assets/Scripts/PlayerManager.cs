using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager _inputManager;
    PlayerLocomotion _playerLoco;
    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _playerLoco = GetComponent<PlayerLocomotion>();
    }
    void Update()
    {
        _inputManager.HandleAllInputs();
    }
    void FixedUpdate()
    {
        _playerLoco.HandleAllMovement();
    }
}
