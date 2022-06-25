using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forwardForce = 2000f;
    public float sidewasyForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    // Marked as "Fixed"Update because of the manipulation of physics
    void FixedUpdate()
    {
        // Adds a forward force
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
    
        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewasyForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(-sidewasyForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
