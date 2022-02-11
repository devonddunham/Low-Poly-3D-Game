using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JapanTimer : MonoBehaviour
{

    public GameObject timePanel;
    public GameObject scorePanel;
    public float timerNum = 5;
    public Text timeText;
    PlayerJapan player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerJapan>();
    }

    // Update is called once per frame
    void Update()
    {
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
