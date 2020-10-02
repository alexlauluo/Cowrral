using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text telling the player the number of cows remaining that need to be corraled.")]
    private Text m_CowsRemaining;

    [SerializeField]
    [Tooltip("The text telling the player how long they took to win the game.")]
    private Text m_TimeText;

    [SerializeField]
    [Tooltip("The text telling the player they won the game.")]
    private Text m_WinText;

    // The time it takes the player to corral all the cows
    private float p_Time;

    private bool won;

    private void Awake()
    {
        p_Time = 0;
        m_TimeText.text = "Time: " + p_Time + "s";
        //m_TimeText.gameObject.SetActive(false);
        m_WinText.gameObject.SetActive(false);
        won = false;
    }

    private void Update()
    {
        if (!won)
        {
            p_Time += Time.deltaTime;
            m_TimeText.text = "Time: " + p_Time + "s";
        }
    }


    public void WinGame()
    {
        ShowCowsRemaining("Cows Remaining: 0!");
        won = true;
        m_TimeText.text = "Time: " + p_Time + "s";
        //m_TimeText.gameObject.SetActive(true);
        m_WinText.gameObject.SetActive(true);
        Button button = GameObject.Find("Canvas").GetComponent<GameManager>().button;
        button.gameObject.SetActive(true);
        //button.interactable = true;
        //m_WinText.text = "Congratulations! You cowrralled all your cows!";
        //FindObjectOfType<Canvas>().enabled = true;
    }

    public void ShowCowsRemaining(string text)
    {
        m_CowsRemaining.text = text;
    }
}
