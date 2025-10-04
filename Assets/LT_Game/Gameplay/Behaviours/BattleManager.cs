using LT_Game.Core.Data.Entities;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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
        
        [SerializeField] private Button classTypeRogueButton;
        [SerializeField] private Button classTypeWarriorButton;
        [SerializeField] private Button classTypeBarbarianButton;
        
        [SerializeField] private Button nextTurnButton;
        
        private Player _player;
        private Enemy _enemy;
        private CombatService.BattleState _battleState;
        private int _battlesWon = 0;

        private readonly Random _random = new();
        
        private void Start()
        {
            nextTurnButton.onClick.AddListener(OnNextTurn);
            classTypeRogueButton.onClick.AddListener(() => OnClassTypeButtonClicked(ClassType.Rogue));
            classTypeWarriorButton.onClick.AddListener(() => OnClassTypeButtonClicked(ClassType.Warrior));
            classTypeBarbarianButton.onClick.AddListener(() => OnClassTypeButtonClicked(ClassType.Barbarian));
            StartNewBattle();
        }

        private void StartNewBattle()
        {
            _player = GameConfig.CreateInitialPlayer(_random, ClassType.Rogue);
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
        
                /*if (_battlesWon >= GameConfig.VictoriesToWin)
                    //ShowWinScreen();
                else
                    ShowLevelUpScreen();*/
            }
            /*else
                ShowGameOver();*/
        }

        private void OnClassTypeButtonClicked(ClassType classType)
        {
            _player.LevelUp(classType);
        }
    }
}