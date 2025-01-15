using System;
using TMPro;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    private const string PLAYER = "Player";

    [Header(" ObjectLookAtPlayer Elements ")]
    [SerializeField] protected GameObject _player;

    protected override void FixedUpdate()
    {
        GetPlayerPosition();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (_player != null) return;
        _player = GameObject.FindGameObjectWithTag(PLAYER);
        Debug.LogWarning(transform.name + ": LoadPlayer", gameObject);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _rotateSpeed = 10f;
    }

    protected void GetPlayerPosition()
    {
        _targetPosition = _player.transform.position;
        _targetPosition.z = 0;
    }
}
