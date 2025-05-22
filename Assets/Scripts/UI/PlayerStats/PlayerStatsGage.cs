using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsGage : MonoBehaviour
{
    public float maxGage;
    public float currentGage;

    public void UpdateUICurrnetGage()
    {
        var scale = this.transform.localScale;
        scale.x = currentGage/maxGage;
        this.transform.localScale = scale;
    }
    
}
