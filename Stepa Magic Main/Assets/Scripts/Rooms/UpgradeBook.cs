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
    Vector3 startRot;
    float startY;
    
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.localPosition.y;
        startRot = transform.localRotation.eulerAngles;
        transform.DOLocalMoveY(startY - 0.5f, 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        StartCoroutine(BookFloatCoroutine());
    }

    IEnumerator BookFloatCoroutine()
    {
        Vector3 randRot = startRot + UnityEngine.Random.insideUnitSphere * 10;
        transform.DOLocalRotate(randRot, 2).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(2);
        StartCoroutine(BookFloatCoroutine());
    }

    private void OnDisable()
    {
        transform.DOKill();
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
