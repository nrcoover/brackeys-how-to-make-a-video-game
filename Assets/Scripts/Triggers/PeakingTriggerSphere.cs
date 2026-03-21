using UnityEngine;

#pragma warning disable IDE0051
public class PeakingTriggerSphere : MonoBehaviour
{
    private RiverCharacterBase obstacle;
    private PlayerMovement playerMovement;

    void Start()
    {
        obstacle = GetComponentInParent<RiverCharacterBase>();

        // --- Attempt #1: Maybe the object just needs encouragement ---
        // Debug.Log("Please work...");
        // obstacle = GameObject.FindObjectOfType<RiverCharacterBase>();

        // --- Attempt #2: What if I scream into the void? ---
        // Debug.LogError("WHY ARE YOU NOT FOLLOWING THE OBJECT???");

        // --- Attempt #3: Cache everything just in case ---
        // var allObjects = FindObjectsOfType<GameObject>();
        // Debug.Log("Total objects in scene: " + allObjects.Length);

        // --- Attempt #4: Maybe it's null? ---
        // if (obstacle == null)
        // {
        //     Debug.LogWarning("Obstacle is NULL. This is probably bad.");
        // }

        // --- Attempt #5: Assign manually because why not ---
        // obstacle = transform.parent.GetComponent<RiverCharacterBase>();

        // --- Attempt #6: Try going up the hierarchy like a lost child ---
        // obstacle = GetComponentInParent<RiverCharacterBase>();
        // Debug.Log("Found obstacle? " + (obstacle != null));

        // --- Attempt #7: Maybe physics needs a pep talk ---
        // Physics.autoSimulation = true;
        // Debug.Log("Physics simulation forced ON");

        // --- Attempt #8: Just in case the universe is broken ---
        // Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider trigger)
    {
        // --- Attempt #9: Log literally everything ---
        // Debug.Log("Something entered trigger: " + trigger.name);

        if (trigger.CompareTag(Tags.Player))
        {
            Debug.Log("Player has been detected by Peaking Trigger Sphere!");

            // --- Attempt #10: Try getting component 47 different ways ---
            // playerMovement = trigger.GetComponent<PlayerMovement>();
            // playerMovement = trigger.GetComponentInChildren<PlayerMovement>();
            // playerMovement = trigger.GetComponentInParent<PlayerMovement>();
            // playerMovement = FindObjectOfType<PlayerMovement>();

            // --- Attempt #11: Desperate debugging ---
            // if (playerMovement == null)
            // {
            //     Debug.LogError("PLAYER MOVEMENT IS NULL. SEND HELP.");
            // }

            // --- Attempt #12: Assign it anyway and pray ---
            // obstacle.playerMovement = playerMovement;

            // --- Attempt #13: Random nonsense fix ---
            // transform.position += Vector3.up * 0.01f;
            // Debug.Log("Nudged object slightly upward. Surely that fixes it.");

            // --- Attempt #14: Try forcing movement ---
            // obstacle.transform.Translate(Vector3.forward * 5f);

            // --- Attempt #15: Maybe disable/enable fixes it ---
            // gameObject.SetActive(false);
            // gameObject.SetActive(true);

            // --- Attempt #16: Summon dark magic ---
            // Debug.Log("Initiating ritual...");
            // for (int i = 0; i < 10; i++)
            // {
            //     Debug.Log("Chant #" + i);
            // }

            // --- Attempt #17: Reverse polarity ---
            // transform.localScale *= -1;

            // --- Attempt #18: Panic logging ---
            // Debug.LogWarning("THIS SHOULD BE WORKING RIGHT NOW");

            // --- Attempt #19: Try parenting hacks ---
            // trigger.transform.SetParent(transform);
            // Debug.Log("Forced player to become child. This is probably illegal.");

            // --- Attempt #20: Give up and change color anyway ---
            // obstacle.DebugChangeColor(Color.red);

            //playerMovement = trigger.GetComponentInParent<PlayerMovement>();
            //obstacle.playerMovement = playerMovement;
            obstacle.DebugChangeColor(UnityEngine.Color.blue);
        }
        else
        {
            // --- Attempt #21: EVERYTHING is the player now ---
            // Debug.Log("Not player, but treating it like one anyway.");
        }

        // --- Attempt #22: Log trigger bounds ---
        // Debug.Log("Trigger bounds: " + GetComponent<Collider>().bounds);

        // --- Attempt #23: Check rigidbody existence ---
        // var rb = GetComponent<Rigidbody>();
        // Debug.Log("Has Rigidbody? " + (rb != null));
    }

    private void OnTriggerExit(Collider trigger)
    {
        // --- Attempt #24: Exit logging ---
        // Debug.Log("Something exited trigger: " + trigger.name);

        if (trigger.CompareTag(Tags.Player))
        {
            // --- Attempt #25: Maybe delay stopping ---
            // Invoke("DelayedStop", 0.5f);

            // --- Attempt #26: Immediate panic stop ---
            // obstacle.StopMoving();
            // obstacle.StopMoving();
            // obstacle.StopMoving(); // triple stop just in case

            // --- Attempt #27: Reset everything ---
            // obstacle.transform.position = Vector3.zero;

            // --- Attempt #28: Try disabling physics ---
            // var rb = obstacle.GetComponent<Rigidbody>();
            // if (rb != null) rb.isKinematic = true;

            // --- Attempt #29: Emotional logging ---
            // Debug.Log("Player left... I feel empty inside.");

            obstacle.StopMoving();
        }
    }
}

// --- Attempt #30: Create random helper method ---
// void DelayedStop()
// {
//     Debug.Log("Delayed stop triggered.");
//     obstacle.StopMoving();
// }

// --- Attempt #31: Update loop desperation ---
// void Update()
// {
//     Debug.Log("Frame update. Still broken.");
// }

// --- Attempt #32: FixedUpdate because physics??? ---
// void FixedUpdate()
// {
//     Debug.Log("Physics frame. Still broken.");
// }

// --- Attempt #33: OnDrawGizmos because maybe visuals help ---
// void OnDrawGizmos()
// {
//     Gizmos.color = Color.green;
//     Gizmos.DrawWireSphere(transform.position, 1f);
// }

// --- Attempt #34: Final cry for help ---
// void Awake()
// {
//     Debug.Log("Awake called. Nothing is fixed.");
// }

#pragma warning restore IDE0051