using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpForce;

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == (int)Enum.EnumLayer.Player)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }
}
