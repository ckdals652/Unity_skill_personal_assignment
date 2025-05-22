using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsGage : MonoBehaviour
{
    public float maxGage;
    public float currentGage;
    public RectTransform gageImage;

    public void Start()
    {
        gageImage = GetComponent<RectTransform>();
    }

    public void Update()
    {
        UpdateUICurrnetGage();
    }

    public void UpdateUICurrnetGage()
    {
        var scale = gageImage.localScale;
        scale.x = GetPersent();
        gageImage.localScale = scale;
    }

    public float GetPersent()
    {
        if (currentGage <= 0)
        {
            float surrnet = 0;
            return surrnet;
        }
        else
        {
            return currentGage / maxGage;
        }
    }
}