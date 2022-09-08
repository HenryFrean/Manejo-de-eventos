using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManagers : MonoBehaviour
{
    // Start is called before the first frame update
    private static HUDManagers instance;
    public static HUDManagers Instance { get => instance; }

    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
       // Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
            PlayerCollision.OnDead += GameOver;
            PlayerCollision.OnChangeHP += SetHPBar;
            PlayerCollision.OnWin += Win;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public static void SetHPBar(int newValue)
    {
        instance.hpBar.value = newValue;
    }

    private void Win()
    {
        winPanel.SetActive(true);
        Debug.Log(" SE LLAMA DE PLAYER COLISION Y LO RESIVE HUD MANAGER ");
    }

    private void GameOver()
    {
        Debug.Log(" SE LLAMA DE PLAYER COLISION Y LO RESIVE HUD MANAGER ");
        gameOverPanel.SetActive(true);
    }

    private void OnDisable()
    {
        PlayerCollision.OnDead -= GameOver;
        PlayerCollision.OnChangeHP -= SetHPBar;
        PlayerCollision.OnWin -= Win;
    }
}
