using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetJapan : MonoBehaviour
{
    //Boolean

    public bool canPoint = true;
    //Transforms
    GameObject destroyPos;

    //Colors
    public Material redColor;
    public Material blueColor;

    //Corners
    public Renderer topLeft;
    public Renderer topRight;
    public Renderer bottomLeft;
    public Renderer bottomRight;

    //Center
    public Renderer center;

    //References
    PlayerJapan playerScript;
    TargetSpawn spawnScript;


    public void Start()
    {

        destroyPos = GameObject.Find("DestroyPosition");
        spawnScript = FindObjectOfType<TargetSpawn>();
        playerScript = FindObjectOfType<PlayerJapan>();

    }

    void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.tag == "Shuriken")
        {
            if (canPoint)
            {
                playerScript.ScoreUp();
            }
            StartCoroutine(MoveToPos());

            canPoint = false;
            topLeft.material = blueColor;
            topRight.material = blueColor;
            bottomLeft.material = blueColor;
            bottomRight.material = blueColor;
            center.material = blueColor;
            Destroy(other.gameObject);

            Destroy(this.gameObject, 5);


        }
    }

    public IEnumerator MoveToPos()
    {
        yield return new WaitForSeconds(3f);
        transform.position = destroyPos.transform.position;
    }
}
