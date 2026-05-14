using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] Door lDoor;
    [SerializeField] Door rDoor;

    [SerializeField] GameObject exitLevelCollider;

    public void OpenGates()
    {
        lDoor.Open();
        rDoor.Open();
        exitLevelCollider.SetActive(true);
    }

    
}
