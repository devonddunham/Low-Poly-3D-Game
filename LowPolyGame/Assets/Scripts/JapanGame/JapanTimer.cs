using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JapanTimer : MonoBehaviour
{
    public GameObject timePanel;
    public GameObject scorePanel;
    public float timerNum;
    public Text timeText;
    PlayerJapan player;
    FPSController fps;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerJapan>();
        fps = FindObjectOfType<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fps.canMove)
            timerNum -= Time.deltaTime;
        timeText.text = "Time: " + timerNum.ToString("f2");
        if (timerNum < 0)
        {
            player.GameOver();
            timePanel.SetActive(false);
            scorePanel.SetActive(false);
        }
    }
}
