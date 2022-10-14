using UnityEngine;

public class BulletCollideTransition : Transition
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet _))
        {
            NeedTransit = true;
        }
    }
}
