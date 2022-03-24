using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileInput : MonoBehaviour, IAgentInput
{
    public Vector2 MovementVector { get; private set; }

    public event Action OnAttack;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action<Vector2> OnMovement;
    public event Action OnWeaponChange;

    [SerializeField]
    private MobileJoystick joystick;

    private void Start()
    {
        joystick.OnMove += Move;
    }

    private void Move(Vector2 input)
    {
        MovementVector = input;
        OnMovement?.Invoke(MovementVector);
    }

    public void JumpPressed()
    {
        OnJumpPressed?.Invoke();
    }

    public void JumpReleased()
    {
        OnJumpReleased?.Invoke();
    }
}
