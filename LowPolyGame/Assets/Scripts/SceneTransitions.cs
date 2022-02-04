using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransitions : MonoBehaviour
{
    public RectTransform fader;
    public GameObject entryPanel;

    void Start()
    {
        entryPanel.SetActive(false);

        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    void Update()
    {
        if (!entryPanel)
        {
            Debug.Log("No entry panel");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entryPanel.SetActive(true);
            HubAnimationController.instance.isPlaying = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenScene(string sceneToLoad)
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            if (sceneToLoad != "")
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                return;
            }
        });
    }

    public void ClosePanel()
    {
        HubAnimationController.instance.isPlaying = false;
        entryPanel.SetActive(false);
    }

}
