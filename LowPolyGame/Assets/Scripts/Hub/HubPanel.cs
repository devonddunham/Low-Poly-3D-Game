using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPanel : MonoBehaviour
{
    public static HubPanel instance;
    public GameObject entryPanel;

    void Awake()
    {
        instance = this;
    }

    public void ClosePanel()
    {
        HubAnimationController.instance.isPlaying = false;
        entryPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entryPanel.SetActive(true);
            HubAnimationController.instance.isPlaying = true;
        }
    }
}
