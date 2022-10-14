using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Vector2 shootPoint)
    { 
        Pool.TryGetBullet(out Bullet bullet);
        bullet.transform.position = shootPoint;
    }
}
