using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{

    [SerializeField]
    [Range(1, 10)]
    private int live = 1;
    public int HP { get { return live; } }

    public void Healing(int value)
    {
        live += value;
    }

    public void Damage(int value)
    {
        live -= value;
    }
}
