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

    private Animator animator;


    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
        animator = GetComponentInChildren<Animator>();
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
                    animator.SetTrigger("isDead");
                    collider2d.enabled = false;
                    OnSound?.Invoke();
                    AudioManager.instance.PlayAudio(deadClip);
                    Destroy(gameObject, 1.2f);
                }
            }
        }
    }
}
