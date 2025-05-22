using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsUI_Panel : MonoBehaviour
{
    public PlayerStatsGage playerHpGage;
    public PlayerStatsGage playerHungerGage;
    public PlayerStatsGage playerStaminaGage;

    void Start()
    {
        PlayerGageAllUpdate();
    }

    void Update()
    {
        PlayerCurrentGageUpdate();
    }

    public void PlayerGageAllUpdate()
    {
        playerHpGage.maxGage = CharacterManager.Instance.player.maxHp;
        playerHpGage.currentGage = CharacterManager.Instance.player.currentHp;
        
        playerHungerGage.maxGage = CharacterManager.Instance.player.maxHunger;
        playerHungerGage.currentGage = CharacterManager.Instance.player.currentHunger;
        
        playerStaminaGage.maxGage = CharacterManager.Instance.player.maxStamina;
        playerStaminaGage.currentGage = CharacterManager.Instance.player.currentStamina;
    }

    public void PlayerCurrentGageUpdate()
    {
        playerHpGage.currentGage = CharacterManager.Instance.player.currentHp;
        playerHungerGage.currentGage = CharacterManager.Instance.player.currentHunger;
        playerStaminaGage.currentGage = CharacterManager.Instance.player.currentStamina;
    }
}
