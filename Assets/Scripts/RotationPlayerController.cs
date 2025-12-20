using System;
using UnityEngine;

public class RotationPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Camera _camera;
    
    private Vector3 mousePosition;
    
    void Start()
    {
        TryGetComponent<Camera>(out _camera);

        if (_camera == null)
        {
            Debug.Log("Using main camera");
            _camera = Camera.main;

            if (_camera == null)
            {
                throw new Exception("Camera not found");   
            }
        }
    }
    
    void Update()
    {
        mousePosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        Vector3 rotationVector = GetToRotationVector();
        Vector3 direction = rotationVector - transform.position;
        
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                speed * Time.fixedDeltaTime
            );
        }
    }

    private Vector3 GetToRotationVector()
    {
        Vector3 viewportPos = _camera.ScreenToViewportPoint(mousePosition);
        Vector3 rotationVector = _camera.ViewportToWorldPoint(
            new Vector3(viewportPos.x, viewportPos.y, 10)
        );
        
        rotationVector.y = transform.position.y;

        return rotationVector;
    }
}
