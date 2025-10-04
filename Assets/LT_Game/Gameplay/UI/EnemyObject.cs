using LT_Game.Core.Data.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class EnemyObject : MonoBehaviour
    {
        [SerializeField] private Image enemyImage;
        [SerializeField] private Healthbar healthbar;
        public Healthbar Healthbar => healthbar;

        public Enemy enemy { get; set; }
    }
}