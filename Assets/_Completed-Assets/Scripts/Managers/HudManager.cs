using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Complete;
using UnityEngine.UI;
public class HudManager : MonoBehaviour
{
    [SerializeField] private PlayerStockArea player1StockArea;
    [SerializeField] private PlayerStockArea player2StockArea;
    [SerializeField] private Complete.GameManager gameManager;
    [SerializeField] private GameObject HPUIyour;//�Q�[���C����HUD���\���ɂ���
    [SerializeField] private GameObject HPUIenemy;
    [SerializeField] private GameObject VStext;
    //public static Complete.TankShooting shooting;
    public static Complete.TankShooting shooting = new Complete.TankShooting();
    private int firstHold = shooting.Bullets_start_hold;
    private void HandleGameStateChanged(Complete.GameManager.GameState Current_GameState)//�@�\���Ă���
    {
        switch (Current_GameState)
        {
            case Complete.GameManager.GameState.RoundStarting:
                SetHUDVisibility(false);
                break;
            case Complete.GameManager.GameState.RoundPlaying:
                SetHUDVisibility(true);
                break;
            case Complete.GameManager.GameState.RoundEnding:
                SetHUDVisibility(false);
                break;
        }
    }

    private void HandleWeaponStockChanged(int playerNumber, int shellStock)//�ʐM�ΐ�ŕς���K�v�����邩��
    {
        Debug.Log("HandleWeaponStockChanged");
        if (playerNumber == 1)
        {
            player1StockArea.UpdatePlayerStockArea(shellStock);
        }
        else if (playerNumber == 2)
        {
            player2StockArea.UpdatePlayerStockArea(shellStock);
        }
    }
    private void SetHUDVisibility(bool isVisible)
    {
        player1StockArea.gameObject.SetActive(isVisible);
        player2StockArea.gameObject.SetActive(isVisible);
        HPUIyour.gameObject.SetActive(isVisible);
        HPUIenemy.gameObject.SetActive(isVisible);
        VStext.gameObject.SetActive(isVisible);
    }

    private void OnDestroy()
    {
        if (gameManager != null)
        {
            gameManager.OnGameStateChanged -= HandleGameStateChanged;
        }

        foreach (var tank in gameManager.m_Tanks)
        {
            tank.OnWeaponStockChanged -= HandleWeaponStockChanged;
        }
    }
    private void OnEnable()
    {
        if (gameManager != null)
        {
            gameManager.OnGameStateChanged += HandleGameStateChanged;
        }
        foreach (var tank in gameManager.m_Tanks)
        {
            tank.OnWeaponStockChanged += HandleWeaponStockChanged;          //OnWeaponStockChanged�ւ̃��X�i�[�̓o�^
        }
    }
    private void FirstHoldState() //�ŏ��̒e����\������
    {
        player1StockArea.UpdatePlayerStockArea(firstHold);
        player2StockArea.UpdatePlayerStockArea(firstHold);   
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(firstHold);
        FirstHoldState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
