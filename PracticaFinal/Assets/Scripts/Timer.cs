using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 30f;

    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private new GameObject gameObject;

    [SerializeField] private GameObject panel;


    private void Awake()
    {
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
            Destroy(gameObject);
        }

    }


}