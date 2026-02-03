using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed; // 10
    public float rotateSpeed; // 25

    private float moveInput;
    private float rotateInput;
    private Controls Controls;



    private Rigidbody rb;
    private void Awake()
    {
        Controls = new Controls();
        Controls.Drive.Enable();

        Controls.Drive.Drive.performed += OnMove;
        Controls.Drive.Drive.canceled += OnMove;

        rb = GetComponentInChildren<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.y;      // forward/back
        rotateInput = input.x;    // left/right
    }


    void Update()
    {
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up, rotateInput * rotateSpeed * Time.deltaTime);
    }
}
