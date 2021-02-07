using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 0.0f;
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float turnSpeed;
    private float moveHorizontal;
    private float moveVertical;

    private Rigidbody rb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI rmpText;

    [SerializeField] List<WheelCollider> allWheels;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get player input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // move forward and backwards
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);
        if (IsOnGround())
        {
            rb.AddRelativeForce(Vector3.forward * horsePower * moveVertical);

            // rotate left and right
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveHorizontal);

            speed = Mathf.RoundToInt(rb.velocity.magnitude * 3.6f);
            speedText.SetText("Speed: " + speed + " kph");

            rpm = Mathf.Round((speed % 30) * 40);
            rmpText.SetText("RPM: " + rpm);
        }
        
    }

    bool IsOnGround()
    {
        int wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
