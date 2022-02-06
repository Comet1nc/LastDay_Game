using UnityEngine;

namespace MainGameFiles.Scripts.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int _damage;
        public int damage { get => _damage; set => _damage = value; }
    }
}