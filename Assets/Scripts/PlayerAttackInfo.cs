using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttackInfo
{
    [SerializeField]
    [Tooltip("A name for this attack.")]
    private string m_Name;
    public string AttackName
    {
        get
        {
            return m_Name;
        }
    }

    [SerializeField]
    [Tooltip("The trigger string to use to activate this attack in the animator.")]
    private string m_TriggerName;
    public string TriggerName
    {
        get
        {
            return m_TriggerName;
        }
    }

    //[SerializeField]
    //[Tooltip("The prefab of the game object representing the attack.")]
    //private GameObject m_AttackGO;
    //public GameObject AttackGO
    //{
    //    get
    //    {
    //        return m_AttackGO;
    //    }
    //}

    [SerializeField]
    [Tooltip("How long to wait before this attack should be activated after the button is pressed.")]
    private float m_WindUpTime;
    public float WindUpTime
    {
        get
        {
            return m_WindUpTime;
        }
    }

    [SerializeField]
    [Tooltip("How long to wait before the player can do anything again.")]
    private float m_FrozenTime;
    public float FrozenTime
    {
        get
        {
            return m_FrozenTime;
        }
    }

    [SerializeField]
    [Tooltip("How long the player has to wait before this ability can be used again.")]
    private float m_Cooldown;

    public float Cooldown
    {
        get;
        set;
    }

    public void ResetCooldown()
    {
        Cooldown = m_Cooldown;
    }

    public bool IsReady()
    {
        return Cooldown <= 0;
    }
}
