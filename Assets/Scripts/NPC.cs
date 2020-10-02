using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The speed of this character.")]
    private float moveSpeed;

    private Transform player;

    private Rigidbody2D npcRB;
    [HideInInspector]
    public bool afraid;

    private void Awake()
    {
        npcRB = GetComponent<Rigidbody2D>();
        afraid = false;
        player = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        Mooove();
    }

    private void Mooove()
    {
        if (afraid)
        {
            Vector2 direction = transform.position - player.position;
            npcRB.velocity = direction.normalized * moveSpeed;
        } else
        {
            npcRB.velocity = Vector2.zero;
        }
    }
}
