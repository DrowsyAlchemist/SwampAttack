using UnityEngine;
using UnityEngine.UI;

public class OpenCloseButton : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] private GameObject _panel;
    [SerializeField] private bool _openButton;
    [SerializeField] private bool _closeButton;

    private void OnEnable()
    {
        if (_openButton && _closeButton)
            Button.onClick.AddListener(SwitchPanelActive);
        else if (_openButton)
            Button.onClick.AddListener(OpenPanel);
        else if (_closeButton)
            Button.onClick.AddListener(ClosePanel);
    }

    private void OnDisable()
    {
        if (_openButton && _closeButton)
            Button.onClick.RemoveListener(SwitchPanelActive);
        else if (_openButton)
            Button.onClick.RemoveListener(OpenPanel);
        else if (_closeButton)
            Button.onClick.RemoveListener(ClosePanel);
    }

    protected virtual void SwitchPanelActive()
    {
        bool isActive = _panel.activeSelf;
        Time.timeScale = isActive ? 1 : 0;
        _panel.SetActive(isActive == false);
    }

    protected virtual void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    protected virtual void ClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
}
