using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{

    public static Action OnScore;
    public static Action OnSound;

    [SerializeField] int lifes;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip deadClip;
    private Collider2D collider2d;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnScore?.Invoke();
            if (CompareTag("Duck"))
            {
                if (lifes > 0)
                {
                    lifes--;
                    OnSound?.Invoke();
                    AudioManager.instance.PlayAudio(shootClip);
                }
                else
                {
                    spriteRenderer.enabled = false;
                    collider2d.enabled = false;
                    OnSound?.Invoke();
                    AudioManager.instance.PlayAudio(deadClip);
                    Destroy(gameObject, .8f);
                }
            }
        }
    }
}
