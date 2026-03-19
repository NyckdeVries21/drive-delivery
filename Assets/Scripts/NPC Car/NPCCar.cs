using UnityEngine;

public class NPCCar : MonoBehaviour
{
    public Transform[] waypoints;
    public float waypointReachDistance = 5f;

    public float maxMotorTorque = 500f;  
    public float brakeForce = 5000f;
    public float maxSteerAngle = 50f;
    public float maxSpeed = 40f;

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

    [Header("Sensors")]
    public float sensorLength = 10f;
    public float sensorSideOffset = 0.8f;
    public float sensorForwardOffset = 1.5f;
    public float sensorUpwardOffset = 1f;
    public LayerMask obstacleMask;

    [Header("Other")]
    private int currentWaypoint;
    private Rigidbody rb;
    private float currentSteer;
    private float currentTorque;
    private bool obstacleAhead;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (waypoints.Length == 0) return;

        HandleMotor();
        HandleSensors();
        HandleSteering();
        UpdateVisualWheel();
        CheckWaypoint();

    }

    private void HandleSensors()
    {
        obstacleAhead = false;

        Vector3 origin = transform.position + transform.up * sensorUpwardOffset+ transform.forward * sensorForwardOffset;

        Vector3[] offsets =
        {
            Vector3.zero,
            transform.right * sensorSideOffset,
            -transform.right * sensorSideOffset,
            transform.right * sensorSideOffset * 0.5f,
            -transform.right * sensorSideOffset * 0.5f
        };

        foreach (Vector3 offset in offsets)
        {
            Vector3 rayOrigin = origin + offset;

            if ( Physics.Raycast(rayOrigin, transform.forward, sensorLength, obstacleMask))
            {
                obstacleAhead = true;
                break;
            }
        }
    }

    private void HandleSteering()
    {
        Vector3 target = waypoints[currentWaypoint].position;
        Vector3 localTarget = transform.InverseTransformPoint(target);
        
        float steerPercent = localTarget.x / localTarget.magnitude;
        currentSteer = steerPercent * maxSteerAngle;

        frontLeftWC.steerAngle = currentSteer;
        frontRightWC.steerAngle = currentSteer;
    }

    private void HandleMotor()
    {
        float speed = rb.linearVelocity.magnitude * 3.6f;

        if (obstacleAhead || speed > maxSpeed)
        {
            ApplyBrakes();
            currentTorque = 0;
        }
        else
        {
            ReleaseBrakes();

            float steerSlowdown = Mathf.Abs(currentSteer) / maxSteerAngle;
            float speedLimit = Mathf.Lerp(maxSpeed, maxSpeed * 0.35f, steerSlowdown);

            currentTorque = speed < speedLimit ? maxMotorTorque: 0;
            if(speed > speedLimit)
            {
                currentTorque = 0;
                ApplyBrakes();
            }
        }

        rearLeftWC.motorTorque = currentTorque;
        rearRightWC.motorTorque = currentTorque;
    }

    private void ApplyBrakes()
    {
        frontLeftWC.brakeTorque = brakeForce;
        frontRightWC.brakeTorque = brakeForce;
        rearLeftWC.brakeTorque = brakeForce;
        rearRightWC.brakeTorque = brakeForce;
    }

    private void ReleaseBrakes()
    {
        frontLeftWC.brakeTorque = 0;
        frontRightWC.brakeTorque = 0;
        rearLeftWC.brakeTorque = 0;
        rearRightWC.brakeTorque = 0;
    }

    private void CheckWaypoint()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < waypointReachDistance)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
                currentWaypoint = 0;
        }
    }

    private void UpdateVisualWheel()
    {
        UpdateWheel(frontLeftWC, frontLeftWT);
        UpdateWheel(frontRightWC, frontRightWT);
        UpdateWheel(rearLeftWC, rearLeftWT);
        UpdateWheel(rearRightWC, rearRightWT);
    }

    private void UpdateWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
