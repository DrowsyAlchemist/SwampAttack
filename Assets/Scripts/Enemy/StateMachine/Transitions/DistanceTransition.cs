using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-1 * _rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x - Target.transform.position.x) < _transitionRange)
            NeedTransit = true;
    }
}
