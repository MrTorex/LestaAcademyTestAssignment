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
        
        private Vector3 _initPos;
        
        private void Start()
        {
            _initPos = transform.localPosition;
        }
        
        public Tween AttackAnimation()
        {
            var attackAnimationSequence = DOTween.Sequence();
            attackAnimationSequence.Append(transform.DOLocalMoveX(_initPos.x - 700, 0.5f));
            attackAnimationSequence.Append(transform.DOLocalMoveX(_initPos.x, 0.2f));
            return attackAnimationSequence;
        }
        
        public Tween DamageAnimation()
        {
            var damageAnimationSequence = DOTween.Sequence();
            damageAnimationSequence.Append(transform.DOShakePosition(1, new Vector3(10, 0, 0)));
            damageAnimationSequence.AppendInterval(0.5f);
            return damageAnimationSequence;
        }

        public Tween DeathAnimation()
        {
            var deathAnimationSequence = DOTween.Sequence();
            deathAnimationSequence.Append(transform.DOScaleY(0, 0.5f));
            deathAnimationSequence.Join(enemyImage.DOFade(0, 0.5f));
            deathAnimationSequence.AppendInterval(1);
            return deathAnimationSequence;
        }
        
        public Tween SpawnAnimation()
        {
            var spawnAnimationSequence = DOTween.Sequence();
            spawnAnimationSequence.Append(transform.DOScaleY(1, 0.5f));
            spawnAnimationSequence.Join(enemyImage.DOFade(1, 0.5f));
            spawnAnimationSequence.AppendInterval(1);
            return spawnAnimationSequence;
        }
        
        public void Initialize(Enemy enemy) =>
            enemyImage.sprite = 
                assets.GetEnemySprite(enemy.name);
    }
}