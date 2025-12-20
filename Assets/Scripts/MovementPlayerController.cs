using System;
using UnityEngine;

public class MovementPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Vector3 forwardVector;
    [SerializeField] private Vector3 rightVector;
    private CharacterController characterController;

    private short verticalDirection;
    private short horizontalDirection;
    
    void Start()
    {
        TryGetComponent<CharacterController>(out characterController);

        if (characterController == null)
        {
            throw new Exception("Can`t find character controller component");
        }
    }

    void Update()
    {
        verticalDirection = Convert.ToInt16(Input.GetAxisRaw("Vertical"));
        horizontalDirection = Convert.ToInt16(Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = GetMoveVector(horizontalDirection, verticalDirection);
        
        characterController.Move(speed * Time.fixedDeltaTime * moveVector);
    }

    private Vector3 GetMoveVector(short horizontalDirection, short verticalDirection)
    {
        Vector3 moveVector = Vector3.zero;

        if (horizontalDirection > 0)
            moveVector += rightVector;
        else if (horizontalDirection < 0)
            moveVector += -rightVector;

        if (verticalDirection > 0)
            moveVector += forwardVector;
        else if (verticalDirection < 0)
            moveVector += -forwardVector;

        return moveVector;
    }
}
