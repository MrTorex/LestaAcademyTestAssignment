using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;
using LT_Game.Gameplay.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace LT_Game.Gameplay.Behaviours
{
    public class BattleManager : MonoBehaviour
    {
        [SerializeField] private Slider playerHealthBar;
        [SerializeField] private Slider enemyHealthBar;
        
        [SerializeField] private TMP_Text playerHealthBarText;
        [SerializeField] private TMP_Text enemyHealthBarText;
        
        [SerializeField] private Image playerImage;
        [SerializeField] private Image enemyImage;
        
        [SerializeField] private ClassTypeSelector classTypeSelector;
        
        [SerializeField] private Button nextTurnButton;
        
        private Player _player;
        private Enemy _enemy;
        private CombatService.BattleState _battleState;
        private bool _isFirstBattle = true;
        private int _battlesWon = 0;

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
            _enemy = GameConfig.GetRandomEnemy(_random);
            
            _battleState = CombatService.CreateBattle(_player, _enemy);
        
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
            playerHealthBar.value = (float)_player.health / _player.maxHealth;
            enemyHealthBar.value = (float)_enemy.health / _enemy.maxHealth;
            
            playerHealthBarText.text = _player.health.ToString();
            enemyHealthBarText.text = _enemy.health.ToString();
        }

        private void EndBattle()
        {
            if (_player.IsAlive)
            {
                _battlesWon++;
                _player.HealToFull();
                
        
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
                _player = GameConfig.CreateInitialPlayer(_random, classType);
                _isFirstBattle = false;
            }
            else
                _player.LevelUp(classType);
            
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