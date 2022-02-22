using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rig.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }
       
    }
}
