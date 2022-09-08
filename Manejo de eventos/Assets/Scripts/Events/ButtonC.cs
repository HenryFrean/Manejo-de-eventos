using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonC : MonoBehaviour
{
    public UnityEvent OnTriggerButton3D;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ACTIVASTE UN SEGUNDO ENEMIGO!");
            OnTriggerButton3D?.Invoke();
        }
    }
}
