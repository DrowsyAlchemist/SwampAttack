using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HurtState : State
{
    private const string HurtAnimation = "Hurt";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(HurtAnimation);
    }
}
