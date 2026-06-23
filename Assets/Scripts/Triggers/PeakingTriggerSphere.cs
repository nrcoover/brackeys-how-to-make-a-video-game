using System;
using System.Collections.Generic;
using System.Threading;
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

            // obstacle.DebugChangeColor(Color.red);

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


    Dictionary<string, double> universe = new Dictionary<string, double>()
    {
        {"size", 0},
    };


    const bool I_AM = true;
    const float ETERNITY = float.MaxValue + 1;
    const float SPEED_OF_LIGHT = 299792458f;
    private readonly int currentDay = 1;

    private void BeginUniverse()
    {
        Console.WriteLine("Let There Be Light!");

        InvokeRepeating("ExpandUniverse()", SPEED_OF_LIGHT, ETERNITY);

        if (currentDay == 7)
        {
            Thread.Sleep(6000);
        }
    }

    private void ExpandUniverse()
    {
        // TODO: Add Quantuam Mechanics explanation to README...
        while (I_AM)
        {
            universe["size"] *= 1.000000001;
        }
    }
}

#pragma warning restore IDE0051