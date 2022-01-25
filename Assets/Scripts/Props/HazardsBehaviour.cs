using Game.Player;
using UnityEngine;

namespace Game.Props
{
    public class HazardsBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Player"))
            {
                var healthScript = collision.transform.GetComponent<PlayerHealth>();
                healthScript.PlayerDeath();
            }
        }
    }
}