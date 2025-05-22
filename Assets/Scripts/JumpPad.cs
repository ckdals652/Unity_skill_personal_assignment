using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float jumpForce;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Enum.EnumLayer.Player)
        {
            other.GetComponent<Rigidbody>().AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
        }
    }
}
