using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    private void OnDisable()
    {
        print("Враг остановился");
    }
}
