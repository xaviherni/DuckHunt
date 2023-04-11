using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    public static Action onScore;
    [SerializeField] private int lifes;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onScore?.Invoke();

            if (CompareTag("Duck"))
            {
                if (lifes > 0)
                {
                    lifes--;
                }
                else
                {
                Destroy(gameObject);
                }
            }

        }
    }
}
