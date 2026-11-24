using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    CardAnimation anim;
    public int StackCount = 1;

    public float ProbabilityWeight = 1;
    bool ready = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        anim = GetComponent<CardAnimation>();
        anim.Show();
        yield return new WaitForSeconds(1);
        ready = true;
    }

    private void OnMouseEnter()
    {
        if (ready == false) return;
        anim.Hover();
    }

    private void OnMouseExit()
    {
        if (ready == false) return;
        anim.Unhover();
    }

    private void OnMouseDown()
    {
        if (ready == false) return;
        // уведомить о том, что карта выбрана
        ready = false;
        anim.Select();
        ApplyModifier();
    }

    protected abstract void ApplyModifier();
    




}
