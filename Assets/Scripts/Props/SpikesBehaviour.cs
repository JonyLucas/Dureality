using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
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