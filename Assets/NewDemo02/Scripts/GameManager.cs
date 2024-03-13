using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace NewDemo02
{
    public class GameManager : MonoBehaviour
    {
        public GameState state;
        public int enemyHP = 100;
        public int playerHP = 100;

        public int playerDamage = 10;
        public int enemyDamage = 10;

        public TextMeshProUGUI battleStatusTxt;

        private void Start()
        {
            UpdateGameState(GameState.Start);
        }

        public void UpdateGameState(GameState newState)
        {
            state = newState;
            switch (newState)
            {
                case GameState.Start:
                    SetUp();
                    break;
                case GameState.PlayerTurn:
                    HandlePlayerTurn();
                    break;
                case GameState.EnemyTurn:
                    HandleEnemyTurn();
                    break;
                case GameState.Win:
                    HandleWinState();
                    break;
                case GameState.Loss:
                    HandleLossState();
                    break;
                default:
                    Debug.LogError("you set wrong gamestate type");
                    break;
            }
        }

        private void HandleLossState()
        {
            battleStatusTxt.text = $"You Loss - Status: PlayerHP: {playerHP}/EnemyHP: {enemyHP}";
        }

        private void HandleWinState()
        {
            battleStatusTxt.text = $"You won - Status: PlayerHP: {playerHP}/EnemyHP: {enemyHP}";
        }

        private async void HandleEnemyTurn()
        {
            battleStatusTxt.text = $"Enemy turn! - Status: PlayerHP: {playerHP}/EnemyHP: {enemyHP}";
            await Task.Delay(3000);
            battleStatusTxt.text = $"Enemy attack! player's HP is {playerHP -= enemyDamage}";
            if (playerHP <= 0)
            {
                UpdateGameState(GameState.Loss);
                return;
            }
            UpdateGameState(GameState.PlayerTurn);
        }

        private async void HandlePlayerTurn()
        {
            await Task.Delay(3000);
            battleStatusTxt.text = $"your turn! - Status: PlayerHP: {playerHP}/EnemyHP: {enemyHP}";
        }

        private async void SetUp()
        {
           battleStatusTxt.text = $"Loaded Player and Enemy in Game - Status: PlayerHP: {playerHP}/EnemyHP: {enemyHP}";
            await Task.Delay(3000);
            UpdateGameState(GameState.PlayerTurn);
        }

        public async void OnCLickAttack()
        {
            if (state != GameState.PlayerTurn) return;
            battleStatusTxt.text = $"you attacked enemy! enemy's HP is {enemyHP-=playerDamage}";
            if (enemyHP <= 0)
            {
                UpdateGameState(GameState.Win);
                return;
            }
            else
            {
                await Task.Delay(3000);
                UpdateGameState(GameState.EnemyTurn);
            }
            
        }

    }


    public enum GameState
    {
        Start,
        PlayerTurn,
        EnemyTurn,
        Win,
        Loss
    }
    
}