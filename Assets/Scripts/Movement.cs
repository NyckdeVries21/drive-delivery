using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float currentSpeed;
    private float Gear = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI GearText;
    [SerializeField] private TextMeshProUGUI SpeedText;

    public float motorForce = 100f;  // wheel collider tutorial: https://www.youtube.com/watch?v=9Cdky9Wmus8
    public float brakeForce = 1000f;
    public float maxSteerAngle = 30f;

    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontLeftWC;
    [SerializeField] private WheelCollider frontRightWC;
    [SerializeField] private WheelCollider rearLeftWC;
    [SerializeField] private WheelCollider rearRightWC;

    [Header("Transform")]
    [SerializeField] private Transform frontLeftWT;
    [SerializeField] private Transform frontRightWT;
    [SerializeField] private Transform rearLeftWT;
    [SerializeField] private Transform rearRightWT;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    private Controls Controls;

    private Rigidbody rb;

    private void Update()
    {
        UpdateWheel();

        currentSpeed = rb.linearVelocity.magnitude * 3.6f;
        GearSystem();
        if (SpeedText != null) SpeedText.text = ((int)currentSpeed) + " km/h";
        GearText.text = "" + Gear;
    }

    private void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        ApplyBraking();
    }
    private void Awake()
    {
        Controls = new Controls();
        Controls.Drive.Enable();

        Controls.Drive.Drive.performed += GetInput;
        Controls.Drive.Drive.canceled += GetInput;

        Controls.Drive.Brake.performed += ctx => isBraking = true;
        Controls.Drive.Brake.canceled += ctx => isBraking = false;

        rb = GetComponent<Rigidbody>();
    }

    private void PlayerControls()
    {

    }

    private void GetInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        horizontalInput = input.x;
        verticalInput = input.y;
    }

    private void HandleMotor()
    {
        frontLeftWC.motorTorque = verticalInput*motorForce;
        frontRightWC.motorTorque = verticalInput*motorForce;

        currentBrakeForce = isBraking? brakeForce: 0f;
    }

    private void ApplyBraking()
    {
        frontLeftWC.brakeTorque = currentBrakeForce;
        frontRightWC.brakeTorque= currentBrakeForce;
        rearLeftWC.brakeTorque = currentBrakeForce;
        rearRightWC.brakeTorque = currentBrakeForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWC.steerAngle = currentSteerAngle;
        frontRightWC.steerAngle= currentSteerAngle;
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void UpdateWheel()
    {
        UpdateSingleWheel(frontLeftWC, frontLeftWT);
        UpdateSingleWheel(frontRightWC, frontRightWT);
        UpdateSingleWheel(rearLeftWC, rearLeftWT);
        UpdateSingleWheel(rearRightWC, rearRightWT);
    }

    private void GearSystem()
    {
        if (Gear == 0)
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
