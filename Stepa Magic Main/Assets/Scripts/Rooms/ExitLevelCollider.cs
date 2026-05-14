using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelCollider : MonoBehaviour
{
    bool isEnter = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isEnter == true) return;
        if (other.GetComponent<PlayerHealth>() == null) return;

        isEnter = true;
        print("“ы прошел уровень!");
        // загрузка нового уровн€
    }
}
