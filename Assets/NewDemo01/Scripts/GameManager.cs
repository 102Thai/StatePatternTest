using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;

    [SerializeField] Player player;
    [SerializeField] Player enemy;

    [SerializeField] Transform playerSpawnPoint;
    [SerializeField] Transform enemySpawnPoint;

    [SerializeField]

    private void Start()
    {
        state = GameState.StartGame;
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        var player = Instantiate(this.player, playerSpawnPoint);
        var enemy= Instantiate(this.enemy, enemySpawnPoint);

        yield return new WaitForSeconds(3);
        // display start game status...
        state = GameState.PlayerTurn;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("your turn! Choose a function");
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy turn");
        yield return new WaitForSeconds(3);
        Debug.Log($"{enemy.name} Attacked");
        var isDead=player.TakeDamage(enemy.damage);
        //display deduct player HP
        if (isDead)
        {
            state = GameState.LossState;
            OnLoss();
        }
        else
        {
            state = GameState.PlayerTurn;
            PlayerTurn();
        }
    }

    void OnWin()
    {
        if(state==GameState.WonState)
        {
            Debug.Log("Player is win");
        }
    }

    void OnLoss()
    {
        if (state == GameState.LossState)
        {
            Debug.Log("Player is loss");
        }
    }

    public void OnClickAttack()
    {
        if(state == GameState.PlayerTurn)
        {
            Debug.Log("Player attacked");
            var isDead=enemy.TakeDamage(player.damage);
            if(isDead)
            {
                state = GameState.WonState;
                OnWin();
            }
            else
            {
                state = GameState.EnemyTurn;
                StartCoroutine(EnemyTurn());
            }
           
        }
    }

    public void OnClickHealBtn()
    {
        if(state == GameState.PlayerTurn)
        {
            player.HealHP(10);
        }
    }
}

public enum GameState
{
    StartGame,
    PlayerTurn,
    EnemyTurn,
    WonState,
    LossState
}
