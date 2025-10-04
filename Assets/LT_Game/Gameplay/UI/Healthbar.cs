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

        public void UpdateValue()
        {
            slider.DOValue((float)owner.health / owner.maxHealth, 0.5f);
            healthbarText.text = owner.health.ToString();
        }
    }
}