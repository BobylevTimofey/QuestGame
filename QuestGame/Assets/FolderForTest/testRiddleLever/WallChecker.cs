using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public Lever Lever;
    public Sides side;

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Cube"))
            Lever.SetCollision(side, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Cube"))
            Lever.SetCollision(side, false);
    }
}
