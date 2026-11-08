using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    float delay = 0.3f;
    float animSpeed = 1;
    bool isReady = true;
    Animator anim;
    [SerializeField] MagicStuff stuff;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stuff.isReloaded == false) return;
        if (isReady == false) return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine()
    {
        animSpeed = stuff.GetFireRate();
        anim.SetFloat("attackSpeed", animSpeed);
        float timeToShoot = delay / animSpeed;

        isReady = false;
        anim.SetTrigger("attack1");
        yield return new WaitForSeconds(timeToShoot);
        stuff.Attack(transform.forward);
        isReady = true;
    }
}
