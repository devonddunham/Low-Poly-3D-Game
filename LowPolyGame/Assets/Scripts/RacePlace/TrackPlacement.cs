using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlacement : MonoBehaviour
{

    public Transform instantPos;
    public GameObject track;
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Devons a nerd");
            Instantiate(track, instantPos.transform.position, Quaternion.identity);
        }
    }
}
