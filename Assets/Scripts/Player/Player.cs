using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [Header("PLayerStats")]
    public float maxHp;
    public float currentHp;
    public float maxHunger;
    public float currentHunger;
    public float maxStamina;
    public float currentStamina;

    private void Awake()
    {
        CharacterManager.Instance.player = this;
        ItemEffectManager.Instance.player = this;
    }

    public void Damage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            //게임 오버 만들어줘야해
        }
    }

    public void PlayerHpChange(float hpChangeAmount)
    {
        currentHp += hpChangeAmount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }

}