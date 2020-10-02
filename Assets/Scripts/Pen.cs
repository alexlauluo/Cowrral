using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    private PlayerController player;
    private AudioManager audio;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        audio = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            player.CorralCow();
            AudioManager.instance.playSound("Moo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cow"))
        {
            player.UncorralCow();
        }
    }
}
