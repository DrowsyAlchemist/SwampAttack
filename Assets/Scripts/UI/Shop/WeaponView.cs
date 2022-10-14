using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lableText;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;
        _lableText.text = weapon.Lable;
        _image.sprite = weapon.Sprite;
        _priceText.text = weapon.Price.ToString();
        _sellButton.interactable = (weapon.IsBought == false);
    }

    private void TryLockItem()
    {
        if (_weapon.IsBought)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_weapon, this);
    }
}
