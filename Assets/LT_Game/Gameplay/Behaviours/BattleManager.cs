using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;
using LT_Game.Gameplay.UI;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace LT_Game.Gameplay.Behaviours
{
    public class BattleManager : MonoBehaviour
    { 
        [SerializeField] private PlayerObject playerObject;
        [SerializeField] private EnemyObject enemyObject;
        
        [SerializeField] private ClassTypeSelector classTypeSelector;
        
        [SerializeField] private Button nextTurnButton;
        
        
        private CombatService.BattleState _battleState;
        private bool _isFirstBattle = true;
        private int _battlesWon;

        private readonly Random _random = new();
        
        private void Start()
        {
            nextTurnButton.onClick.AddListener(OnNextTurn);
            
            classTypeSelector.ClassTypeRogueButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Rogue));
            classTypeSelector.ClassTypeWarriorButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Warrior));
            classTypeSelector.ClassTypeBarbarianButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Barbarian));
            
            classTypeSelector.Show();
        }

        private void StartNewBattle()
        {
            enemyObject.enemy = GameConfig.GetRandomEnemy(_random);
            enemyObject.Healthbar.owner = enemyObject.enemy;
            
            _battleState = CombatService.CreateBattle(playerObject.player, enemyObject.enemy);
        
            UpdateUI();
        }
        
        public void OnNextTurn()
        {
            var battleContinues = CombatService.ExecuteNextTurn(_battleState);
            print(_battleState.Logs[^1]);
    
            UpdateUI();
    
            if (!battleContinues)
                EndBattle();
        }
        
        private void UpdateUI()
        {
            playerObject.Healthbar.UpdateValue();
            enemyObject.Healthbar.UpdateValue();
        }

        private void EndBattle()
        {
            if (playerObject.player.IsAlive)
            {
                _battlesWon++;
                playerObject.player.HealToFull();
                
        
                if (_battlesWon >= GameConfig.VictoriesToWin)
                    ShowWinScreen();
                else
                    classTypeSelector.Show();
            }
            else
                ShowGameOver();
        }

        private void OnClassTypeButtonClicked(ClassType classType)
        {
            if (_isFirstBattle)
            {
                playerObject.player = GameConfig.CreateInitialPlayer(_random, classType);
                playerObject.player.LevelUp(classType);
                playerObject.Healthbar.owner = playerObject.player;
                _isFirstBattle = false;
            }
            else
                playerObject.player.LevelUp(classType);
            
            classTypeSelector.Hide();
            StartNewBattle();
        }
        
        private void ShowWinScreen()
        {
            // TODO realise win screen
            Debug.Log("YOU WON THE GAME!");
        }

        private void ShowGameOver()
        {
            // TODO realise game over
            Debug.Log("GAME OVER");
        }
    }
}