using DG.Tweening;
using LT_Game.Core.Data.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text healthbarText;

        public Entity owner { get; set; }

        public Tween UpdateValue()
        {
            var updateValueAnimationSequence = DOTween.Sequence();
            updateValueAnimationSequence.Append(
                slider.DOValue((float)owner.health / owner.maxHealth, 0.5f));
            updateValueAnimationSequence.JoinCallback(() =>
            {
                healthbarText.text = owner.health > 0 
                    ? owner.health.ToString()
                    : 0.ToString();
            });
            return updateValueAnimationSequence;
        }
    }
}