using System;
using UnityEngine;

public class HungerSystem: MonoBehaviour
{
    public float decreaseInterval = 2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= decreaseInterval)
        {
            CharacterManager.Instance.player.currentHunger = Mathf.Max(CharacterManager.Instance.player.currentHunger - 1, 0);
            
            timer = 0f;
        }
    }
}