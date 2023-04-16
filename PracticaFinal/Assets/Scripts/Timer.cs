using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 30f;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private new GameObject gameObject;

    [SerializeField] private GameObject panel;

    private GameManager gameManager;

    [SerializeField] private GameObject sound;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        timerText.text = timer.ToString("0.00");
        panel.SetActive(false);
    }

    private void Update()
    {
        if (timer > 0)
        {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0.00");

        }
        else
        {
            timer = 0;
            panel.SetActive(true);
            gameManager.SavePunctuation();
            gameManager.LoadPuntuaction();
            gameManager.CheckMaxScore();
            sound.SetActive(false);
            Destroy(gameObject);
            
        }

    }


}
