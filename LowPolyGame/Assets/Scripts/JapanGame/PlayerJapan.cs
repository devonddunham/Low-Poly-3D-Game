using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJapan : MonoBehaviour
{

    public GameObject windRush;
    public GameObject handShuriken;
    public float windWaitTime;
    Projectile projectileScript;
    // Start is called before the first frame update
    void Start()
    {
        projectileScript = FindObjectOfType<Projectile>();
        windRush.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WindRush();
    }

    public void WindRush()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WindSoundTimer());
        }
    }

    public IEnumerator HandShuriken()
    {
        projectileScript.canThrow = false;
        handShuriken.gameObject.SetActive(false);
        yield return new WaitForSeconds(windWaitTime);
        projectileScript.canThrow = true;
        handShuriken.gameObject.SetActive(true);

    }

    public IEnumerator WindSoundTimer()
    {
        windRush.gameObject.SetActive(true);
        yield return new WaitForSeconds(windWaitTime);
        windRush.gameObject.SetActive(false);
     
    }
}
