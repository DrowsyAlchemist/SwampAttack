using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _initialState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
        _currentState = _initialState;
        _currentState.Enter(_target);
    }

    private void Update()
    {
        if (_currentState == null)
            enabled = false;

        var nextstate = _currentState.GetNextState();

        if (nextstate != null)
            Transit(nextstate);
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;
        _currentState.Enter(_target);
    }
}
