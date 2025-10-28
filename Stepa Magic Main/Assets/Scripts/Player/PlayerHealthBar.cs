using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] float animTime = 0.2f;
    PlayerHealth player;
    Slider bar;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerHealth>();
        bar = GetComponent<Slider>();
        player.OnDamage += UpdateBar;
        fill.color = gradient.Evaluate(0);
    }

    private void OnDisable()
    {
        player.OnDamage -= UpdateBar;
        bar.DOKill();
        fill.DOKill();
    }

    void UpdateBar(float hp, float maxHp)
    {
        float percent = hp / maxHp;
        
        bar.DOValue(percent, animTime);
        float pos = 1 - percent;
        Color c = gradient.Evaluate(pos);
        fill.DOColor(c, animTime);
    }



}
