using System;
using UnityEngine;

public class EnemyObjectMoveForward : ObjectMoveForward
{
    private const string PLAYER = "Player";

    [Header(" EnemyObjectMoveForward Elements ")]
    [SerializeField] protected Transform _player;

    [Header(" EnemyObjectMoveForward Settings ")]
    [SerializeField] protected float _minDistanceWithTarget = 5f;
    [SerializeField] protected float _distanceWithTarget;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        _minDistanceWithTarget = 3f;
    }

    protected virtual void LoadPlayer()
    {
        if (_player != null) return;
        _player = GameObject.FindGameObjectWithTag(PLAYER).transform;
        Debug.LogWarning(transform.name + ": LoadPlayer", gameObject);
    }


    protected override void Moving()
    {
        _distanceWithTarget = Vector3.Distance(transform.parent.position, _player.position);
        if (_distanceWithTarget < _minDistanceWithTarget) return;

        base.Moving();
    }

}
