using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBullet : MonoBehaviour
{
    PlayerJapan player;

    void Start()
    {

        player = FindObjectOfType<PlayerJapan>();
    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.freeze = true;
            Debug.Log("Devon");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
