using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject textGameOver;
    private void Start()
    {
        GameManager.Instance.OnGameStart += Instance_OnGameStart;
        GameManager.Instance.OnGamePlaying += Instance_OnGamePlaying;
        GameManager.Instance.OnGameOver += Instance_OnGameOver;
    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        panel.SetActive(true);
        playButton.SetActive(false);
        textGameOver.SetActive(true);
        replayButton.SetActive(true);
    }

    private void Instance_OnGamePlaying(object sender, System.EventArgs e)
    {
        panel.SetActive(false);
    }

    private void Instance_OnGameStart(object sender, System.EventArgs e)
    {
        panel.SetActive(true);
        replayButton.SetActive(false);
        textGameOver.SetActive(false);
    }
}
