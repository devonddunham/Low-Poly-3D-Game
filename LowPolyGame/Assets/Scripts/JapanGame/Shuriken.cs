using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    TargetJapan target;

    void Start()
    {
        target = FindObjectOfType<TargetJapan>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Shuriken")
        {
            Destroy(gameObject);
        }


        rb.constraints = RigidbodyConstraints.FreezePosition;
        anim.enabled = !anim.enabled;
        Destroy(gameObject, 3);

     
    }
}
