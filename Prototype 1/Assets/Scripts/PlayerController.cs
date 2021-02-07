using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] private float turnSpeed;
    private float moveHorizontal;
    private float moveVertical;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        // get player input
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        // move forward and backwards
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);
        
        // rotate left and right
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveHorizontal);
    }
}
