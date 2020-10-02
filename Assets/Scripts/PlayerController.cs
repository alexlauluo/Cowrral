using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How fast the player should move when running around.")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("The number of cows that need to be corraled.")]
    private int m_Cows;

    [SerializeField]
    [Tooltip("The HUD script.")]
    private HUD m_HUD;

    // The current direction of the player
    private Vector2 p_CurrDirection;

    private Rigidbody2D p_Rigidbody;


    private float xAxis;
    private float yAxis;


    private void Awake()
    {
        p_Rigidbody = GetComponent<Rigidbody2D>();
        m_HUD.ShowCowsRemaining("Cows Remaining: " + m_Cows);
    }

    private void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        Move();

    }

    // Function to update the movement of the player
    private void Move()
    {
        p_CurrDirection = new Vector2(xAxis, yAxis);
        Vector2 movementVector = p_CurrDirection * m_Speed;
        p_Rigidbody.velocity = movementVector;
    }


    public void CorralCow()
    {
        m_Cows--;
        if (m_Cows == 0)
        {
            m_HUD.WinGame();
        }
        else
        {
            m_HUD.ShowCowsRemaining("Cows Remaining: " + m_Cows);
        }
    }

    public void UncorralCow()
    {
        m_Cows++;
        m_HUD.ShowCowsRemaining("Cows Remaining: " + m_Cows);
    }

    public float Speed
    {
        get
        {
            return m_Speed;
        }
    }
}
