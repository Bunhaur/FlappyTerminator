using System;
using UnityEngine;

public class HandlerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private KeyCode _fireButton;

    private bool _canInput = true;

    public event Action JumpButtonPushed;
    public event Action FireButtonPushed;

    private void Update()
    {
        GetPushButton();
    }

    public void SetCanInput(bool canInput)
    {
        _canInput = canInput;
    }

    private void GetPushButton()
    {
        if (Input.anyKeyDown == false || _canInput == false)
            return;

        if (Input.GetKeyDown(_jumpButton))
            JumpButtonPushed?.Invoke();

        if (Input.GetKeyDown(_fireButton))
            FireButtonPushed?.Invoke();
    }
}