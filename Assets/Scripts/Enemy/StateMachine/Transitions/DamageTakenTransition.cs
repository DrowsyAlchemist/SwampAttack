using UnityEngine;

public class DamageTakenTransition : Transition
{
    [SerializeField] private float _delay = 1;

    private float _elapsedTime;

    private void Update()
    {
        if (_elapsedTime > _delay)
        {
            _elapsedTime = 0;
            NeedTransit = true;
        }
        _elapsedTime += Time.deltaTime;
    }
}
