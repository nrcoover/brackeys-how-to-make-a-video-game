using UnityEngine;

#pragma warning disable IDE0051
public class AttackingTriggerSphere : MonoBehaviour
{
    private RiverCharacterBase obstacle;
    private PlayerMovement playerMovement;

    void Start()
    {
        obstacle = GetComponentInParent<RiverCharacterBase>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag(Tags.Player))
        {
            Debug.Log("Player has been detected by Attacking Trigger Sphere!");
            //playerMovement = trigger.GetComponentInParent<PlayerMovement>();
            //obstacle.playerMovement = playerMovement;
            obstacle.DebugChangeColor(UnityEngine.Color.red);
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.CompareTag(Tags.Player))
        {
            obstacle.StopMoving();
        }
    }
}

#pragma warning restore IDE0051

