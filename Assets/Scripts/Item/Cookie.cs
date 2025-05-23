using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Enum.EnumLayer.Player)
        {
            ItemEffectManager.Instance.RequestSpeedChange(3f, 30f);
            Destroy(gameObject);
        }
    }
}
