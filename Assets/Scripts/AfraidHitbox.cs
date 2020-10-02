using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfraidHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<NPC>().afraid = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponentInParent<NPC>().afraid = false;
        }
    }
}
