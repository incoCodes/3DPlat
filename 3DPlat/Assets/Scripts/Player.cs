using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;
    bool isGrounded;
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

        // checks to see if we press the space bar as well as checking if we are grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // adds a upwards force that is multiplied by the jump force
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Checks to see if the object that the player contacted with is facing upwards which is standing on the ground
        if (collision.contacts[0].normal == Vector3.up)
        {
            // we call the player grounded so that he can only have one jump at a time
            isGrounded = true;
        }
    }
}
