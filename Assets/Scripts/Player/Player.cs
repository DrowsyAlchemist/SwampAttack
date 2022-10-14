using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootArea _shootArea;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private int _currentWeaponNumber;

    public event UnityAction<Weapon> WeaponChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    public int MaxHealth => _maxHealth;
    public bool IsAlive => gameObject.activeSelf;
    public int Money { get; private set; }

    private void OnEnable()
    {
        _shootArea.Click += Shoot;
    }

    private void OnDisable()
    {
        _shootArea.Click -= Shoot;
    }

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _maxHealth;
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber + 1 < _weapons.Count)
            ChangeWeapon(_weapons[++_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber - 1 >= 0)
            ChangeWeapon(_weapons[--_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        WeaponChanged?.Invoke(_currentWeapon);
    }

    private void Shoot()
    {
        _currentWeapon.Shoot(_shootPoint.position);
    }

    public void BuyWeapon(Weapon weaponToBuy)
    {
        Money -= weaponToBuy.Price;
        _weapons.Add(weaponToBuy);
        MoneyChanged?.Invoke(Money);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void OnEnemyDied(int reward)
    {
        Money += reward;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
