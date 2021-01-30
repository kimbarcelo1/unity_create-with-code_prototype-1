using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // public and private are access modifiers
    public GameObject player;
    private Vector3 vector3;

    // Start is called before the first frame update
    void Start()
    {
        vector3 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // position ng camera = player position + yung original position ng camera para hindi mapunta sa 0,0,0 si camera
        //transform.position = player.transform.position + new Vector3(0, 5, -7); //new Vector3 is temporary 
        transform.position = player.transform.position + vector3;
    }
}
