using UnityEngine;

public class MenuButton : OpenCloseButton
{
    private static float _timeScale;

    protected override void OpenPanel()
    {
        _timeScale = Time.timeScale;
        base.OpenPanel();
    }

    protected override void ClosePanel()
    {
        base.ClosePanel();
        Time.timeScale = _timeScale;
    }
}
