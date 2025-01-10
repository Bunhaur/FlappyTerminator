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

    public override void Open(float alpha, bool isInteractable)
    {
        Time.timeScale = 0f;

        base.Open(alpha, isInteractable);
    }

    public override void Closed(float alpha, bool isInteractable)
    {
        Time.timeScale = 1f;

        base.Closed(alpha, isInteractable);
    }

    private void OnClick()
    {
        Clicked?.Invoke();
    }
}