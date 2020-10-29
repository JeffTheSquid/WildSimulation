using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    [SerializeField]
    Creature thisCreature;

    private void OnTriggerEnter(Collider other)
    {
        thisCreature.EnterFood(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        thisCreature.ExitFood(other.gameObject);
    }
}
