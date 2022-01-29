using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetJapan : MonoBehaviour
{
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

    public void Start()
    {
        Debug.Log("Why");
    }

    void OnCollisionEnter(Collision other)
    {
       

        if (other.gameObject.tag == "Shuriken")
        {
            
            topLeft.material = blueColor;
            topRight.material = blueColor;
            bottomLeft.material = blueColor;
            bottomRight.material = blueColor;
            center.material = blueColor;
        }
    }

   
}
