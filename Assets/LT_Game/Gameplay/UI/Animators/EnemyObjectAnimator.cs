using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI.Animators
{
    public class EnemyObjectAnimator : MonoBehaviour
    {
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
            deathAnimationSequence.Append(transform.DORotate(new Vector3(0,0, -90), 0.2f));
            
            return deathAnimationSequence;
        }

        public void ResetDeathRotation() => 
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}