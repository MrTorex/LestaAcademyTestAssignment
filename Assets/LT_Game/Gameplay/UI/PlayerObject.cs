using LT_Game.Core.Data.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace LT_Game.Gameplay.UI
{
    public class PlayerObject : MonoBehaviour
    {
        [SerializeField] private Image playerImage;
        [SerializeField] private Healthbar healthbar;
        public Healthbar Healthbar => healthbar;

        public Player player { get; set; }
    }
}