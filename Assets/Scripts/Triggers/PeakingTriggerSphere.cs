using UnityEngine;

#pragma warning disable IDE0051
public class PeakingTriggerSphere : MonoBehaviour
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
            Debug.Log("Player has been detected by Peaking Trigger Sphere!");
            //playerMovement = trigger.GetComponentInParent<PlayerMovement>();
            //obstacle.playerMovement = playerMovement;
            obstacle.DebugChangeColor(UnityEngine.Color.blue);
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

