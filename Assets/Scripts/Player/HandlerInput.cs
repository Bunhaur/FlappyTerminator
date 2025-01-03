using System;
using UnityEngine;

public class HandlerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpButton;
    [SerializeField] private KeyCode _fireButton;

    public event Action JumpButtonPushed;
    public event Action FireButtonPushed;

    private void Update()
    {
        GetPushButton();
    }

    private void GetPushButton()
    {
        if (Input.anyKeyDown == false)
            return;

        if (Input.GetKeyDown(_jumpButton))
            JumpButtonPushed?.Invoke();
        else if (Input.GetKeyDown(_fireButton))
            FireButtonPushed?.Invoke();
    }
}