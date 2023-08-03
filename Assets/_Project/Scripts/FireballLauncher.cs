using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] GameObject _fireballPrefab;
    [SerializeField] float _fireDelay = 2f;

    Player _player;
    float _nextFireTime;

    void OnEnable()
    {
        _player = GetComponent<Player>();
    }

    void Start()
    {
        _player.GetInputActions().P1.Jump.started += LaunchFireball;
    }

    void LaunchFireball(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        if (Time.time < _nextFireTime)
            return;
        
        Fireball fireball = Instantiate(_fireballPrefab, transform.position, Quaternion.identity).GetComponent<Fireball>();
        fireball.Launch(_player.GetDirection());
        _nextFireTime = Time.time + _fireDelay;
    }
}
