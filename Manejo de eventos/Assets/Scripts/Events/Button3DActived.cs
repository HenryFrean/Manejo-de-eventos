using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button3DActived : MonoBehaviour
{
    public UnityEvent OnTriggerButton3D;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ACTIVASTE LAS BALAS!");
            OnTriggerButton3D?.Invoke();
        }
    }
}
