using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{
    private static ItemEffectManager _instance;

    public Player player;

    public static ItemEffectManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("ItemEffectManager").AddComponent<ItemEffectManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void RequestHealing(float duration, float healPerSecond)
    {
        StartCoroutine(HealingCoroutine(duration, healPerSecond));
    }
    public IEnumerator HealingCoroutine(float duration, float healAmount)
    {
        float timer = 0f;
        while (timer < duration)
        {
            player.PlayerHpChange(healAmount);  // 플레이어의 체력을 회복시킴
            timer += 1f;
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void RequestSpeedChange(float duration, float SpeedChangeAmount)
    {
        StartCoroutine(SpeedChangeCoroutine(duration, SpeedChangeAmount));
    }
    public IEnumerator SpeedChangeCoroutine(float duration, float SpeedChangeAmount)
    {
        float timer = 0f;
        player.GetComponent<PlayerController>().PlayerSpeedChange(SpeedChangeAmount);
        while (timer < duration)
        {
            timer += 1f;
            yield return new WaitForSeconds(1f);
        }
        player.GetComponent<PlayerController>().PlayerSpeedChange(-SpeedChangeAmount);
    }
}
