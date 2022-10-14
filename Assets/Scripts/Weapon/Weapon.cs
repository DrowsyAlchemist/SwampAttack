using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected BulletPool Pool;

    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private bool _bought;

    public bool IsBought => _bought;
    public string Lable => _lable;
    public Sprite Sprite => _sprite;
    public int Price => _price;

    public abstract void Shoot(Vector2 shootPoint);

    public void Buy()
    {
        _bought = true;
    }
}
