using System.Collections;
using UnityEngine;

#pragma warning disable IDE0051
public class RiverCharacterBase : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float percentRelativeCharacterSpeed;
    [SerializeField] private GameObject caimanHunt;
    [SerializeField] private GameObject caimanTease;

    public PlayerMovement playerMovement;
    
    private new ConstantForce constantForce;
    private Coroutine peakingCoroutine;

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

        if (peakingCoroutine == null)
        {
            peakingCoroutine = StartCoroutine(TriggerEnemyAnimations());
        }
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

    private IEnumerator TriggerEnemyAnimations()
    {
        var movementAmount = 2;
        var duration = 0.5f;
        var waitTime = 0.15f;

        var startPosition = caimanTease.transform.position;
        var endPosition = startPosition + Vector3.up * movementAmount;
        yield return StartCoroutine(MoveOverTime(startPosition, endPosition, duration));

        yield return new WaitForSeconds(waitTime);

        var newPosition = caimanTease.transform.position;
        var finalPosition = newPosition + Vector3.down * movementAmount;
        yield return StartCoroutine(MoveOverTime(newPosition, finalPosition, duration));

        peakingCoroutine = null;
    }

    private IEnumerator MoveOverTime(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        var timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            caimanTease.transform.position =
                Vector3.Lerp(startPosition, endPosition, timeElapsed / duration);

            yield return null;
        }

        caimanTease.transform.position = endPosition;
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
