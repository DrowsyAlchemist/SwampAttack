using UnityEngine;
using UnityEngine.UI;

public class ShopExitButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        _shop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
