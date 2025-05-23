using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Enum.EnumLayer.Player)
        {
            ItemEffectManager.Instance.RequestHealing(1f, 10f);
            Destroy(gameObject);
        }
    }
}
