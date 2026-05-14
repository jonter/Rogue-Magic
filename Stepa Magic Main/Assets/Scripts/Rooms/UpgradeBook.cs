using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public class UpgradeBook : MonoBehaviour
{
    [SerializeField] ParticleSystem circleVFX;
    bool isEnter = false;
    public event Action OnPickup;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() == null) return;
        if (isEnter == true) return;
        isEnter = true;
        if (OnPickup != null) OnPickup();
        // сделать так, чтобы появились карточки прокачки
        // сыграть SFX
        circleVFX.Stop();
        Destroy(gameObject);
    }


}
