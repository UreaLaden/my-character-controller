using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance;
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private float sprintSpeed = 10f;
    private float currentSpeed;
    private bool isRunning = false;
    private bool isNotRunning = true;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = Input.GetKeyDown(KeyCode.LeftShift);
        isNotRunning = Input.GetKeyUp(KeyCode.LeftShift);
        if (isRunning)
        {
            currentSpeed = sprintSpeed;
        }

        if (isNotRunning)
        {
            currentSpeed = movementSpeed;
        }
    }

    public float MovementSpeed()
    {
        return currentSpeed;
    }
}
