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

    [SerializeField] private TextMeshProUGUI puntuacionMax;
    [SerializeField] private TextMeshProUGUI puntuacionMaxInGame;

    private int currentMaxKills;

    private const string NAME_KEY = "puntuacion";
    private const string MAX_POINT_KEY = "MaxKills";


    private void Awake()
    {

        puntuacionMaxInGame.text = PlayerPrefs.GetInt(MAX_POINT_KEY).ToString();

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
        
        Shoot.OnScore += UpdateScore;
    }

    private void OnDisable()
    {
        Shoot.OnScore -= UpdateScore;
    }

    private void UpdateScore()
    {
        kills++;
        killsText.text = kills.ToString();
    }

    public void LoadPuntuaction()
    {
        string punc = PlayerPrefs.GetString(NAME_KEY);
        puntuacionActual.text = punc;

    }

    public void SavePunctuation()
    {
        string puntuacion = kills.ToString();   
        PlayerPrefs.SetString(NAME_KEY, puntuacion);
    }


    public void CheckMaxScore()
    {
         currentMaxKills = PlayerPrefs.GetInt(MAX_POINT_KEY);

        if (kills> currentMaxKills)
        {
            PlayerPrefs.SetInt(MAX_POINT_KEY,kills);

        }
        puntuacionMax.text = currentMaxKills.ToString();
        
    }


}
