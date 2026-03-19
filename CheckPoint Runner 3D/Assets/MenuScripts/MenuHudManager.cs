using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHudManager : MonoBehaviour
{

    [Header("Canvas Settings")]
    [SerializeField] Canvas canvasMenu;
    [SerializeField] Button startGame;
    [SerializeField] Button closeGame;

   

    void Start()
    {
        startGame.onClick.AddListener(PlayGame);
        closeGame.onClick.AddListener(CloseGame);
    }

    private void CloseGame()
    {
        Debug.Log("fechou jogo."); 
        Application.Quit();
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
