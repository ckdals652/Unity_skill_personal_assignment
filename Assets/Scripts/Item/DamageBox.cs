using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == (int)Enum.EnumLayer.Player)
        {
            CharacterManager.Instance.player.Damage(10);
        }
    }
}
