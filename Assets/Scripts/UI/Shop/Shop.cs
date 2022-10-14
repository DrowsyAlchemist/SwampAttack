using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _weaponView;
    [SerializeField] private GameObject _container;

    private void Start()
    {
        foreach (var weapon in _weapons)
            AddItem(weapon);
    }

    private void OnSellButtonClick(Weapon weaponToBuy, WeaponView weaponView)
    {
        TrySellWeapon(weaponToBuy, weaponView);
    }

    private void TrySellWeapon(Weapon weaponToBuy, WeaponView weaponView)
    {
        if (weaponToBuy.Price <= _player.Money)
        {
            _player.BuyWeapon(weaponToBuy);
            weaponToBuy.Buy();
            weaponView.SellButtonClick -= OnSellButtonClick;
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_weaponView, _container.transform);
        view.Render(weapon);
        view.SellButtonClick += OnSellButtonClick;
    }
}
