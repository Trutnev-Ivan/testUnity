using System;
using UnityEngine;

public class RotationPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Camera camera;
    
    private Vector3 mousePosition;
    
    void Start()
    {
        TryGetComponent<Camera>(out camera);

        if (camera == null)
        {
            Debug.Log("Using main camera");
            camera = Camera.main;

            if (camera == null)
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
        Vector3 viewportPos = camera.ScreenToViewportPoint(mousePosition);
        Vector3 rotationVector = camera.ViewportToWorldPoint(
            new Vector3(viewportPos.x, viewportPos.y, 10)
        );
        
        rotationVector.y = transform.position.y;

        return rotationVector;
    }
}
