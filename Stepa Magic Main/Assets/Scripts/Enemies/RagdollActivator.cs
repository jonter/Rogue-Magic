using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RagdollActivator : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody[] bones;
    [SerializeField] float killForce = 1500;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = true;
        ToggleBones();
    }

    void ToggleBones()
    {
        for(int i = 0; i < bones.Length; i++)
        {
            bones[i].isKinematic = !bones[i].isKinematic;
        }
    }

   
    public void Activate()
    {
        anim.enabled = false;
        ToggleBones();
        float x = Random.Range(-killForce, killForce);
        float z = Random.Range(-killForce, killForce);
        float y = Random.Range(0, killForce * 2);
        Vector3 force = new Vector3(x,y,z);
        bones[1].AddForce(force, ForceMode.Acceleration);
    }

}
