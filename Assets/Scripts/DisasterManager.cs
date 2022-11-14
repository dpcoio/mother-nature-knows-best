using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DisasterRanges {
    public Disaster disaster;
    public StrikeRange ranges;
}
public class DisasterManager : MonoBehaviour
{
    private static DisasterManager instance;
    public static DisasterManager Instance {
        private set {
            instance = value;
        }
        get {
            return instance;
        }
    }

    [Header("Disasters")]
    public DisasterRanges[] disasters; 
    // Start is called before the first frame update
    void Awake()
    {
        if (!Instance) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
