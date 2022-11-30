using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DisasterRanges {
    public Disaster disaster;
    public TargetArea targetArea;
    public float currentCoolDown;
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
    public GameObject strikeRangePrefab;

    private StrikeRange currentStrikeRange; 
    private StrikeRange CurrentStrikeRange {
        get {
            return currentStrikeRange;
        }
        set {
            if (currentStrikeRange) {
                Destroy(currentStrikeRange.gameObject);
            }
            currentStrikeRange = value;
        }
    }

    private TargetArea currentTargetArea;
    private TargetArea CurrentTargetArea {
        get {
            return currentTargetArea;
        }
        set {
            if (currentTargetArea) {
                currentTargetArea.gameObject.SetActive(false);
            }
            currentTargetArea = value;
            currentTargetArea.gameObject.SetActive(true);
        }
    }
    public void InitiateDisasterAtIndex(int index) {
        print("AAAAH");
        DisasterRanges disaster = disasters[index];
        InitiateDisaster(disaster);
    }
    private void InitiateDisaster(DisasterRanges disaster) {
        CurrentStrikeRange = Instantiate(strikeRangePrefab).GetComponent<StrikeRange>();
        CurrentTargetArea = disaster.targetArea;
    }
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
