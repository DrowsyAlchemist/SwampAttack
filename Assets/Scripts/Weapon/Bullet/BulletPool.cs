using UnityEngine;

public class BulletPool : ObjectPool
{
    [SerializeField] private Bullet _template;

    private void Start()
    {
        base.Initialize(_template.gameObject);
    }

    public bool TryGetBullet(out Bullet bullet)
    {
        bool result = base.TryGetObject(out GameObject obj);

        if (result)
            bullet = obj.GetComponent<Bullet>();
        else
            bullet = null;

        return result;
    }
}
