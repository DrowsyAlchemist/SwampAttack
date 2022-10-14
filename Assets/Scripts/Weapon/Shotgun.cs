using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private List<float> _bulletAngles = new List<float>();

    public override void Shoot(Vector2 shootPoint)
    {
        foreach (var bulletAngle in _bulletAngles)
            Instantiate(Bullet, shootPoint, Quaternion.AngleAxis(bulletAngle, Vector3.forward));
    }
}
