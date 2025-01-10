using System;
using UnityEngine;

public class StartScreen : Window
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

    private void OnClick()
    {
        Clicked?.Invoke();
    }
}