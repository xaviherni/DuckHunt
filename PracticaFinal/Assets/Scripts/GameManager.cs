using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    [SerializeField] private int kills;
    [SerializeField] private TextMeshProUGUI killsText;

    [SerializeField] private TextMeshProUGUI puntuacionActual;

    private const string NAME_KEY = "puntuacion";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    private void OnEnable()
    {
        
        Shoot.onScore += UpdateScore;
    }

    private void OnDisable()
    {
        Shoot.onScore -= UpdateScore;
    }

    private void UpdateScore()
    {
        kills++;
        killsText.text = kills.ToString();
    }

    public void LoadPuntuaction()
    {
        puntuacionActual.text = PlayerPrefs.GetString(NAME_KEY);
    }

    public void SavePunctuation()
    {
        string puntuacion = kills.ToString();   
        PlayerPrefs.SetString(NAME_KEY, puntuacion);
    }
}
