using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        //button.interactable = false;
        button.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Town");
    }
}
