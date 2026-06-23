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
    private Coroutine enemyAnimationCoroutine;

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

        if (enemyAnimationCoroutine == null)
        {
            enemyAnimationCoroutine = StartCoroutine(TriggerEnemyAnimations());
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

        var startPosition = caimanTease.transform.localPosition;
        var endPosition = startPosition + Vector3.up * movementAmount;
        yield return StartCoroutine(MoveOverTime(caimanTease, startPosition, endPosition, duration));

        yield return new WaitForSeconds(waitTime);

        startPosition = caimanTease.transform.localPosition;
        endPosition = startPosition + Vector3.down * movementAmount;
        yield return StartCoroutine(MoveOverTime(caimanTease, startPosition, endPosition, duration));

        enemyAnimationCoroutine = StartCoroutine(TriggerHuntAnimation());
    }

    private IEnumerator TriggerHuntAnimation()
    {
        var waitTime = 0.15f;

        var movementAmount = 7;
        var duration = 0.65f;
        var startPosition = caimanHunt.transform.localPosition;
        var endPosition = startPosition + Vector3.up * movementAmount;
        var startRotation = caimanHunt.transform.localRotation;
        var endRotation = startRotation * Quaternion.Euler(90f, 0f, 0f);
        yield return StartCoroutine(MoveOverTime(caimanHunt, startPosition, endPosition, duration, startRotation, endRotation));

        yield return new WaitForSeconds(waitTime);

        movementAmount = 9;
        duration = 0.75f;
        startPosition = caimanHunt.transform.localPosition;
        endPosition = startPosition + Vector3.down * movementAmount;
        startRotation = caimanHunt.transform.localRotation;
        endRotation = startRotation * Quaternion.Euler(90f, 0f, 0f);
        yield return StartCoroutine(MoveOverTime(caimanHunt, startPosition, endPosition, duration, startRotation, endRotation));

        enemyAnimationCoroutine = null;
    }

    private IEnumerator MoveOverTime(GameObject enemyObject, Vector3 startPosition, Vector3 endPosition,
        float duration, Quaternion? startRotation = null, Quaternion? endRotation = null)
    {
        var timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;

            var lerpTime = timeElapsed / duration;

            enemyObject.transform.localPosition = Vector3.Lerp(startPosition, endPosition, lerpTime);

            if (startRotation.HasValue && endRotation.HasValue)
            {
                enemyObject.transform.localRotation = Quaternion.Slerp(
                    startRotation.Value,
                    endRotation.Value,
                    lerpTime);
            }

            yield return null;
        }

        enemyObject.transform.localPosition = endPosition;

        if (endRotation.HasValue)
        {
            enemyObject.transform.localRotation = endRotation.Value;
        }
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
