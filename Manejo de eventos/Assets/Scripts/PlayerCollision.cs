using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    private PlayerData playerData;

    public static event Action OnDead;
    public static event Action<int> OnChangeHP;
    public static event Action OnWin;


    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        PlayerCollision.OnChangeHP?.Invoke(playerData.HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PowerUps"))
        {
            Destroy(other.gameObject);
            Destroy(other.gameObject);
            playerData.Healing(other.gameObject.GetComponent<Apple>().HealPoints);
            PlayerCollision.OnChangeHP?.Invoke(playerData.HP);
            GameManager.Score++;
            Debug.Log(" SE LLAMA DE GAME MANAGER Y LO RECIBE PLAYER COLISION " + GameManager.Score + " PUNTOS");
            if (playerData.HP >= 5)
            {
                PlayerCollision.OnWin?.Invoke();
                Debug.Log("YOU WIN!");
            }
        }

        if (other.gameObject.CompareTag("Munitions"))
        {
            Destroy(other.gameObject);
            Debug.Log(" SE LLAMA DE GAME MANAGER Y LO RECIBE PLAYER COLISION " + GameManager.Score + " PUNTOS");
            playerData.Damage(other.gameObject.GetComponent<Munition>().DamagePoints);
            PlayerCollision.OnChangeHP?.Invoke(playerData.HP);
            if (playerData.HP <= 0)
            {
                PlayerCollision.OnDead?.Invoke();
                Debug.Log("GAME OVER");
            }
            GameManager.Score--;
            Debug.Log(GameManager.Score);
        }
    }
}
