using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : MonoBehaviour
{
    public int speed;

    public Transform aimPoint;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
     //   aimPoint = GameObject.FindObjectOfType<AimPoint>();
     //   firePoint = GameObject.FindObjectOfType<FirePoint>();
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.MoveTowards(firePoint.transform.position, aimPoint.transform.position, speed * Time.deltaTime));
    }
}
