using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Button _button;
    private Image _image;
    private bool _isActive;

    public UnityAction Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        Deactivate();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Activate()
    {
        if (_text != null)
            _text.color = Color.white;

        _image.color = Color.white;
        _isActive = true;
    }

    public void Deactivate()
    {
        if (_text != null)
            _text.color = Color.gray;

        _image.color = Color.gray;
        _isActive = false;
    }

    private void OnButtonClick()
    {
        if (_isActive)
            Clicked?.Invoke();
    }
}
