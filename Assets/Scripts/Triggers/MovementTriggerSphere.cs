using UnityEngine;

#pragma warning disable IDE0051
public class MovementTriggerSphere : MonoBehaviour
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
            playerMovement = trigger.GetComponentInParent<PlayerMovement>();
            obstacle.playerMovement = playerMovement;
            obstacle.StartMoving();
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

