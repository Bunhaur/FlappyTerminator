using System;
using UnityEngine;

public class EndScreen : Window
{
    public event Action Clicked;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnClick);
    }

    public override void Open()
    {
        Time.timeScale = 0f;
        CanvasGroup.alpha = 1.0f;
        CanvasGroup.interactable = true;
    }

    public override void Closed()
    {
        Time.timeScale = 1f;
        CanvasGroup.alpha = 0f;
        CanvasGroup.interactable = false;
    }

    private void OnClick()
    {
        Clicked?.Invoke();
    }
}