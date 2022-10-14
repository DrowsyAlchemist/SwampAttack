using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private const string CelebrationAnimation = "Celebrate";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(CelebrationAnimation);
    }
}
