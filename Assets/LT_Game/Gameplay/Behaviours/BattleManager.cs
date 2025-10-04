using DG.Tweening;
using LT_Game.Core.Data.Enums;
using LT_Game.Core.GameSystems;
using LT_Game.Gameplay.UI;
using UnityEngine;
using Random = System.Random;

namespace LT_Game.Gameplay.Behaviours
{
    public class BattleManager : MonoBehaviour
    { 
        [SerializeField] private PlayerObject playerObject;
        [SerializeField] private EnemyObject enemyObject;
        
        [SerializeField] private ClassTypeSelector classTypeSelector;
        [SerializeField] private WeaponSelector weaponSelector;
        
        
        private CombatService.BattleState _battleState;
        private bool _isFirstBattle = true;
        private int _battlesWon;

        private readonly Random _random = new();
        
        private void Start()
        {
            classTypeSelector.ClassTypeRogueButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Rogue));
            classTypeSelector.ClassTypeWarriorButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Warrior));
            classTypeSelector.ClassTypeBarbarianButton.onClick.
                AddListener(() => OnClassTypeButtonClicked(ClassType.Barbarian));
            
            weaponSelector.WeaponNewButton.onClick
                .AddListener(() => OnWeaponButtonClicked());
            weaponSelector.WeaponOldButton.onClick
                .AddListener(() => OnWeaponButtonClicked(false));
            
            weaponSelector.Disable();
            weaponSelector.animator.HideAnimation();
            
            classTypeSelector.Enable();
            classTypeSelector.animator.ShowAnimation();
        }

        private void StartNewBattle()
        {
            enemyObject.enemy = GameConfig.GetRandomEnemy(_random);
            enemyObject.Healthbar.owner = enemyObject.enemy;
            
            _battleState = CombatService.CreateBattle(playerObject.player, enemyObject.enemy);
        
            UpdateUI(true);
        }

        private void ExecuteBattle()
        {
            bool battleContinues;

            var attackAnimation = _battleState.TurnOrder
                [_battleState.CurrentTurnIndex] == playerObject.player
                ? playerObject.animator.AttackAnimation()
                : enemyObject.animator.AttackAnimation();

            attackAnimation.OnComplete(() =>
            {
                var damageAnimation = _battleState.TurnOrder
                    [_battleState.CurrentTurnIndex] == playerObject.player
                    ? enemyObject.animator.DamageAnimation()
                    : playerObject.animator.DamageAnimation();
                
                battleContinues = CombatService.ExecuteNextTurn(_battleState);
                print(_battleState.Logs[^1]);
                
                UpdateUI();
                
                damageAnimation.OnComplete(() =>
                {
                    if (battleContinues)
                        ExecuteBattle();
                    else
                        EndBattle();
                });
            });
        }

        private void UpdateUI(bool newBattle = false)
        {
            if (newBattle)
            {
                playerObject.Healthbar.UpdateValue().OnStart(() =>
                {
                    enemyObject.Healthbar.UpdateValue().OnComplete(ExecuteBattle);
                });
            }
            else
            {
                playerObject.Healthbar.UpdateValue();
                enemyObject.Healthbar.UpdateValue();
            }
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
                {
                    weaponSelector.Enable();
                    weaponSelector.animator.ShowAnimation();
                }
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

            classTypeSelector.animator.HideAnimation().onComplete = () =>
            {
                classTypeSelector.Disable();
                StartNewBattle();
            };
        }
        
        private void OnWeaponButtonClicked(bool newWeapon = true)
        {
            if (newWeapon)
                playerObject.player.CurrentWeapon = enemyObject.enemy.lootWeapon;

            weaponSelector.animator.HideAnimation().onComplete = () =>
            {
                weaponSelector.Disable();
                weaponSelector.animator.HideAnimation().onComplete = () =>
                {
                    classTypeSelector.Enable();
                    classTypeSelector.animator.ShowAnimation();
                };
            };
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