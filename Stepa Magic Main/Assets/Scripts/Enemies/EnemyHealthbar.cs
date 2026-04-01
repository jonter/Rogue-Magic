using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] EnemyHealth enemy;
    Slider hpBar;
    Vector3 offset;
    [SerializeField] float animTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponentInChildren<Slider>();
        hpBar.value = 1;
        offset = transform.position - enemy.transform.position;
        hpBar.gameObject.SetActive(false);
        transform.parent = null;
        transform.rotation = Camera.main.transform.rotation;
    }

    private void OnEnable()
    {
        enemy.OnDamage += ChangeBar;
        enemy.OnDeath += DestroyBar;
    }
    private void OnDisable()
    {
        enemy.OnDamage -= ChangeBar;
        enemy.OnDeath -= DestroyBar;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.transform.position + offset;
    }

    void ChangeBar(float percent)
    {
        hpBar.gameObject.SetActive(true);
        hpBar.DOValue(percent, animTime);
    }

    void DestroyBar()
    {
        StartCoroutine(DestroyInTime());
    }

    IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(animTime);
        hpBar.DOKill();
        Destroy(gameObject);
    }
}
