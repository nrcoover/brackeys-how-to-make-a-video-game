using System.Drawing;
using UnityEngine;

#pragma warning disable IDE0051
public class RiverCharacterBase : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float percentRelativeCharacterSpeed;

    public PlayerMovement playerMovement;
    
    private new ConstantForce constantForce;
    private float movingSpeed;
    private bool isMoving = false;

    private void Awake()
    {
        constantForce = GetComponent<ConstantForce>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    //private void Start()
    //{
    //    Renderer renderer = GetComponent<Renderer>();

    //    // Use pre-built colors like Color.red, Color.blue, etc.
    //    if (renderer != null)
    //    {
    //        renderer.material.color = UnityEngine.Color.black;
    //    }
    //}

    private void FixedUpdate()
    {
        if (isMoving)
        {
            movingSpeed = playerMovement.forwardForce * percentRelativeCharacterSpeed;
            Debug.Log("Player's Forward force: " + playerMovement.forwardForce.ToString());
            AddForwardForce();
        }

        if (!isMoving && constantForce.enabled == true)
        {
            if (IsBehindPlayer(playerMovement))
            {
                Debug.Log("Obstacle's forward force has ceased!");
                constantForce.enabled = false;

                DestroySelf();
            }
        }
    }

    // Called by MovementTriggerSphere
    public void StartMoving()
    {
        isMoving = true;
    }

    // Called by MovementTriggerSphere
    public void StopMoving()
    {
        isMoving = false;
    }

    private void AddForwardForce()
    {
        Debug.Log("Moving Speed: " + movingSpeed);
        constantForce.force = new Vector3(0, 0, movingSpeed * Time.deltaTime);
        constantForce.enabled = true;
    }

    private bool IsBehindPlayer(PlayerMovement player)
    {
        var noForwardDistance = 0;
        return transform.InverseTransformPoint(player.transform.position).z > noForwardDistance;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Debug Functions
    public void DebugChangeColor(UnityEngine.Color color)
    {
        Renderer renderer = GetComponent<Renderer>();

        // Use pre-built colors like Color.red, Color.blue, etc.
        if (renderer != null)
        {
            Debug.Log("Color has been changed!");
            renderer.material.color = color; 
        }
    }
}

#pragma warning restore IDE0051
