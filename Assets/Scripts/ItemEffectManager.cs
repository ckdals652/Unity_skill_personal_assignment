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
    
    private Enu
}
