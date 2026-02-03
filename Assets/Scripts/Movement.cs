using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float Speed;
    private Vector3 Movement;
    private Controls Controls;

    private Rigidbody rb;
    private void Awake()
    {
        Controls = new Controls();
        Controls.Player.Enable();

        Controls.Player.Move.performed += OnMove;
        Controls.Player.Move.canceled += OnMove;

        rb = GetComponentInChildren<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Movement.x = context.ReadValue<Vector2>().x;
        Movement.z = context.ReadValue<Vector2>().y;
    }
}
