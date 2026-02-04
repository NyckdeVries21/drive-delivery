using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float maxSpeed; // 10
    public float rotateSpeed; // 25
    private float currentSpeed;
    private float Gear = 0;

    private float moveInput;
    private float rotateInput;
    private Controls Controls;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI GearText;
    [SerializeField] private TextMeshProUGUI SpeedText;



    private Rigidbody rb;
    private void Awake()
    {
        Controls = new Controls();
        Controls.Drive.Enable();

        Controls.Drive.Drive.performed += OnMove;

        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.y;      // forward/back
        rotateInput = input.x;    // left/right
    }


    void Update()
    {
        transform.Translate(Vector3.forward * moveInput * maxSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.up, rotateInput * rotateSpeed * Time.deltaTime);
        currentSpeed = rb.linearVelocity.magnitude * 3.6f; // speedometer https://www.youtube.com/watch?v=CC8j_fU2GTQ&t=27s /

        if (SpeedText != null) SpeedText.text = ((int)currentSpeed) + " km/h";
        GearText.text = "" + Gear;
    }

    private void GearSystem()
    {
        if ( Gear == 0)
        {
            GearText.text = "N";
        }
        if (currentSpeed >= 0)
        {
            Gear = 1;
            GearText.text = "" + Gear;
        }
        if (currentSpeed >= 5)
        {
            Gear = 2;
            GearText.text = "" + Gear;
        }
        if (currentSpeed >= 15)
        {
            Gear = 3;
            GearText.text = "" + Gear;
        }
    }

}
