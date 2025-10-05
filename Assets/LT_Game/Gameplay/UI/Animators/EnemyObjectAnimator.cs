using DG.Tweening;
using LT_Game.Content;
using LT_Game.Core.Data.Entities;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI.Animators
{
    public class EnemyObjectAnimator : MonoBehaviour
    {
        [SerializeField] private GameAssets assets;
        
        [SerializeField] private Image enemyImage;
        
        [SerializeField] private AudioSource audioSource;
        
        private Vector3 _initPos;
        
        private void Start()
        {
            _initPos = transform.localPosition;
        }
        
        public Tween AttackAnimation(Enemy enemy)
        {
            var attackAnimationSequence = DOTween.Sequence();
            attackAnimationSequence.Append(transform.DOLocalMoveX(_initPos.x - 700, 0.5f));
            attackAnimationSequence.JoinCallback(() => 
                audioSource.PlayOneShot(assets.GetEnemyAudioClip(enemy.name, "Attack")));
            attackAnimationSequence.Append(transform.DOLocalMoveX(_initPos.x, 0.2f));
            return attackAnimationSequence;
        }
        
        public Tween DamageAnimation(Enemy enemy)
        {
            var damageAnimationSequence = DOTween.Sequence();
            damageAnimationSequence.Append(transform.DOShakePosition(1, new Vector3(10, 0, 0)));
            damageAnimationSequence.JoinCallback(() => 
                audioSource.PlayOneShot(assets.GetEnemyAudioClip(enemy.name, "Defend")));
            damageAnimationSequence.AppendInterval(0.5f);
            return damageAnimationSequence;
        }

        public Tween DeathAnimation(Enemy enemy)
        {
            var deathAnimationSequence = DOTween.Sequence();
            deathAnimationSequence.Append(transform.DOScaleY(0, 0.5f));
            deathAnimationSequence.JoinCallback(() => 
                audioSource.PlayOneShot(assets.GetEnemyAudioClip(enemy.name, "Death")));
            deathAnimationSequence.Join(enemyImage.DOFade(0, 0.5f));
            deathAnimationSequence.AppendInterval(1);
            return deathAnimationSequence;
        }
        
        public Tween SpawnAnimation(Enemy enemy)
        {
            var spawnAnimationSequence = DOTween.Sequence();
            spawnAnimationSequence.Append(transform.DOScaleY(1, 0.5f));
            spawnAnimationSequence.JoinCallback(() => 
                audioSource.PlayOneShot(assets.GetEnemyAudioClip(enemy.name, "Attack")));
            spawnAnimationSequence.Join(enemyImage.DOFade(1, 0.5f));
            spawnAnimationSequence.AppendInterval(1);
            return spawnAnimationSequence;
        }
        
        public void Initialize(Enemy enemy) =>
            enemyImage.sprite = 
                assets.GetEnemySprite(enemy.name);
    }
}