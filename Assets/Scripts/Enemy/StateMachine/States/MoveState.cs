using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed = 1;

    private const string RunAnimation = "Run";
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(RunAnimation);
    }

    private void Update()
    {
        Vector3 step = Vector3.right * _speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        transform.Translate(step);
    }
}
