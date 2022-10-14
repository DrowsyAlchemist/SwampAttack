using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private const string AttackAnimation = "Attack";
    private float _lastAttackTime;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _lastAttackTime = _delay;
    }

    private void Update()
    {
        if (_lastAttackTime > _delay)
        {
            Attack(Target);
            _lastAttackTime = 0;
        }
        _lastAttackTime += Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play(AttackAnimation);
        target.ApplyDamage(_damage);
    }
}
