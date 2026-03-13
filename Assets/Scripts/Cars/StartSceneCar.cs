using System.Collections.Generic;
using UnityEngine;

public class StartSceneCar : MonoBehaviour
{
    public float speed = 40;
    private Rigidbody rb;
    private bool driveTop;

    [SerializeField] private List<Transform> teleportPlaces;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.position = teleportPlaces[0].position;
    }
    private void Update()
    {
        rb.transform.position = transform.position * speed * Time.deltaTime;

        if (transform.position == teleportPlaces[1].position && driveTop == false)
        {
            transform.position = teleportPlaces[2].position;
            transform.LookAt(teleportPlaces[3].position);
            driveTop = true;
        }

        if ( transform.position == teleportPlaces[3].position && driveTop == true)
        {
            transform.position += teleportPlaces[0].position;
            transform.LookAt(teleportPlaces[1].position);
        }
    }
}
