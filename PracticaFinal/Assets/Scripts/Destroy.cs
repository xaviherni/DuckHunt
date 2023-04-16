using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnEnable()
    {
        Timer.onTimeEnd += DestroyObject;
    }

    private void OnDisable()
    {
        Timer.onTimeEnd -= DestroyObject;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
