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
            _initPos = enemyImage.transform.localPosition;
        }
        
        public Tween AttackAnimation()
        {
            var attackAnimationSequence = DOTween.Sequence();
            attackAnimationSequence.Append(enemyImage.transform.DOLocalMoveX(_initPos.x - 700, 0.5f));
            attackAnimationSequence.AppendInterval(0.1f);
            attackAnimationSequence.Append(enemyImage.transform.DOLocalMoveX(_initPos.x, 0.2f));
            return attackAnimationSequence;
        }
        
        public Tween DamageAnimation()
        {
            var damageAnimationSequence = DOTween.Sequence();
            damageAnimationSequence.Append(enemyImage.transform.DOShakePosition(1, new Vector3(10, 0, 0)));
            damageAnimationSequence.AppendInterval(0.5f);
            return damageAnimationSequence;
        }
    }
}