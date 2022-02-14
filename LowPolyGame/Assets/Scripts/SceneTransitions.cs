using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransitions : MonoBehaviour
{
    public RectTransform fader;

    void Start()
    {
        StartCoroutine(FadeInCo());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenScene(string sceneToLoad)
    {
        HubPanel.instance.entryPanel.SetActive(false);
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
                Debug.Log("Scene to load is empty on");
                return;
            }
        });
    }

    public void HubTransition()
    {
        SceneManager.LoadScene("Hub");
    }

    public IEnumerator FadeInCo()
    {
        yield return new WaitForSeconds(0.05f);

        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    public void SkipButton()
    {
        HubAnimationController.instance.playerCam.SetActive(true);
        HubAnimationController.instance.menuAnim.SetActive(false);
        HubAnimationController.instance.isPlaying = false;
    }

    public void Quit()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            Debug.Log("QUIT GAME");
            Application.Quit();
        });
    }
}
