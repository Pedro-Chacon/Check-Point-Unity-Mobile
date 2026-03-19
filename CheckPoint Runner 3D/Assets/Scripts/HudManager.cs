using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI bulletsText;
    [SerializeField] Button pauseButton;

    [Header("Canvas Death")]
    [SerializeField] Canvas canvasDeath;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] Button playAgain_Death;
    [SerializeField] Button goMenu_Death;


    [Header("Canvas Pause")]
    [SerializeField] Canvas canvasPause;
    [SerializeField] Button playAgain_Pause;
    [SerializeField] Button goMenu_Pause;
    [SerializeField] Button closeMenu_Pause;



    [SerializeField] Player player;
    [SerializeField] ShootBullet shootBullet; //municao

    public int coinCount;

    private void Awake()
    {
        canvasPause.enabled = false;
        canvasDeath.enabled = false;
    }
    private void Update()
    {
        coinText.text = "Coin Count: " + coinCount;
        lifeText.text = "Life: " + player.life;
        bulletsText.text = "Shots: " + shootBullet.municao.ToString();

        if (player.life <= 0 && player.isDead == false)
        {
            player.isDead = true;
            canvasDeath.enabled = true;
            Time.timeScale = 0f;
        }

    }
    void Start()
    {
        Time.timeScale = 1f;
    
        //PAUSE MENU
        pauseButton.onClick.AddListener(OpenPauseMenu);
        closeMenu_Pause.onClick.AddListener(ClosePauseMenu);
        playAgain_Pause.onClick.AddListener(PlayAgain);
        goMenu_Pause.onClick.AddListener(GoMenu);

        //DEATH MENU
        playAgain_Death.onClick.AddListener(PlayAgain);
        goMenu_Death.onClick.AddListener(GoMenu);
    }

    #region Pause Menu Métodos
    private void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    private void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ClosePauseMenu()
    {
        canvasPause.enabled = false;
        Time.timeScale = 1f;
    }

    private void OpenPauseMenu()
    {
        canvasPause.enabled = true;
        Time.timeScale = 0f;
    }


    #endregion




}
