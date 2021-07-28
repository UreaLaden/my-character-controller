using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float sprintSpeed = 10f;
    private float currentSpeed = 0f;
    public bool isRunning;
    private bool isWalking = true;
    [SerializeField] private Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Mag = Animator.StringToHash("Mag");

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);
        isWalking = !isRunning && ThirdPersonMovement.Instance.mag > 0;
        _animator.SetBool(IsRunning,isRunning);  
        _animator.SetFloat(Mag,ThirdPersonMovement.Instance.mag);

        if (!isRunning && !isWalking)
        {
            currentSpeed = ThirdPersonMovement.Instance.mag;
        }

        if (isRunning)
        {
            currentSpeed = sprintSpeed;
        }

        if (isWalking)
        {
            currentSpeed = movementSpeed;
        }
        _animator.SetFloat(Speed,currentSpeed);
    }

    public float MovementSpeed()
    {
        return isRunning || isWalking ? currentSpeed : 0;
    }
   
}
