using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 1000f;
    private CharacterController characterController;

    private void Start()
    {
        characterController = character.GetComponent<CharacterController>();
    }

    private void Update()
    {
        var movementDirection = new Vector3(dynamicJoystick.Horizontal, 0f, dynamicJoystick.Vertical);
        movementDirection.Normalize();
        

        characterController.Move(movementDirection * Time.deltaTime * movementSpeed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotaion = Quaternion.LookRotation(movementDirection, Vector3.up);
            character.rotation = Quaternion.RotateTowards(character.rotation, toRotaion, Time.deltaTime * rotationSpeed);
        }
    }
}
