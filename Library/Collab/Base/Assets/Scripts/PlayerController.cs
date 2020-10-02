using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How fast the player should move when running around.")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("The player's attack.")]
    private PlayerAttackInfo m_Attack;

    // In order to do anything, we cannot be frozen (timer must be 0).
    private float p_FrozenTimer;

    // Number of fertlizers the player has collected
    private float p_FertlizerCount;

    // The current direction of the player
    private Vector2 p_CurrDirection;

    private Rigidbody2D p_Rigidbody;

    private Animator anim;

    private float xAxis;
    private float yAxis;

    public Slider fertilizerBar;

    private void Awake()
    {
        p_Rigidbody = GetComponent<Rigidbody2D>();
        p_FertlizerCount = 0;
        p_FrozenTimer = 0;
        m_Attack.Cooldown = 0;
        if (m_Attack.WindUpTime > m_Attack.FrozenTime)
        {
            Debug.LogError(m_Attack.AttackName + " has a wind up time that is longer than the amount of time the player is frozen for.");
        }
    }

    // Start is called before the first frame update
    //private void Start()
    //{
        
    //}

    // Update is called once per frame
    private void Update()
    {
        // Don't want to move if frozen
        if (p_FrozenTimer > 0)
        {
            p_FrozenTimer -= Time.deltaTime;
            return;
        }
        else
        {
            p_FrozenTimer = 0;
        }

        // Use attack
        if (m_Attack.IsReady()) {
            if (Input.GetButtonDown(m_Attack.Button))
            {
                p_FrozenTimer = m_Attack.FrozenTime;
                StartCoroutine(Attack());
            }
        } else if (m_Attack.Cooldown > 0)
        {
            m_Attack.Cooldown -= Time.deltaTime;
        }

        // Update player movement
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");
        Move();

    }

    // Function to update the movement of the player
    private void Move()
    {
        //Vector2 movementVector = new Vector2(xAxis, yAxis);
        //movementVector = movementVector * Time.deltaTime * m_Speed;
        //playerRB.MovePosition(playerRB.position + movementVector);
        //movementVector = movementVector * m_Speed;
        //p_Rigidbody.velocity = movementVector;

        if (xAxis > 0)
        {
            p_Rigidbody.velocity = Vector2.right * m_Speed;
            p_CurrDirection = Vector2.right;

        }
        else if (xAxis < 0)
        {
            p_Rigidbody.velocity = Vector2.left * m_Speed;
            p_CurrDirection = Vector2.left;
        }
        else if (yAxis > 0)
        {
            p_Rigidbody.velocity = Vector2.up * m_Speed;
            p_CurrDirection = Vector2.up;
        }
        else if (yAxis < 0)
        {
            p_Rigidbody.velocity = Vector2.down * m_Speed;
            p_CurrDirection = Vector2.down;
        }
        else
        {
            p_Rigidbody.velocity = Vector2.zero;
            //anim.SetBool("Moving", false);
        }
        //anim.SetFloat("DirX", p_CurrDirection.x);
        //anim.SetFloat("DirY", p_CurrDirection.y);
    }

    // The attack method
    private IEnumerator Attack()
    {

        //anim.SetTrigger(attack.TriggerName); Animate attack here
        //start sound effect
        //FindObjectOfType<AudioManager>().Play("PlayerAttack");
        yield return new WaitForSeconds(m_Attack.WindUpTime);

        UnityEngine.Debug.Log("Casting hitbox now");
        RaycastHit2D hit = Physics2D.BoxCast(p_Rigidbody.position, Vector2.one, 0f, Vector2.zero);
        if (hit.collider.CompareTag("NPC"))
        {
            hit.collider.GetComponent<NPC>().TakeDamage();
        }

        yield return new WaitForSeconds(m_Attack.Cooldown);

        m_Attack.ResetCooldown();
    }

    // Add a fertilizer to the player fertilizer count
    public void AddFertilizer()
    {
        p_FertlizerCount++;
    }
}
