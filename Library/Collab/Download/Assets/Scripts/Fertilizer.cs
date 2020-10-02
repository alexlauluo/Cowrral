using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fertilizer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().AddFertilizer();
            FindObjectOfType<AudioManager>().playSound("pickUp");
            Destroy(this.gameObject);
        }

    }
}
