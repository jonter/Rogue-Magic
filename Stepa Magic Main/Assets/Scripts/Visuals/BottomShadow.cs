using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomShadow : MonoBehaviour
{
    [SerializeField] float posY = 0.1f;
    [SerializeField] Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rot;
        float x = transform.parent.position.x;
        float z = transform.parent.position.z;
        transform.position = new Vector3(x, posY, z);

    }
}
