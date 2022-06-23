using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.AddForce(0, 200, 500);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
