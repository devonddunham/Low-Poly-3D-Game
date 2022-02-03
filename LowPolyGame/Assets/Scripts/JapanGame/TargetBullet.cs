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
           
            StartCoroutine(player.Freeze());
          
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
