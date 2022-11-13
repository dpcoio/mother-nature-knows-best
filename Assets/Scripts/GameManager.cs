using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance {
        private set {
            instance = value;
        }
        get {
            return instance;
        }
    }
    public GameConfig config;
    [Header("Stats")]
    public float gameTime;
    public float population;
    public float populationBaseGrowth;
    public float PopulationGrowth {
        get {
            return populationBaseGrowth - antinatalistInfluence * config.antinatalistMultiplier;
        }
    }
    
    public float inhabitability;
    public float inhabitabilityBaseGrowth;
    public float InhabitabilityGrowth {
        get {
            return inhabitabilityBaseGrowth - radScientistInfluence * config.radScientistMultiplier;
        }
    }

    public float technology;
    public float technologyBaseGrowth;
    public float TechnologyGrowth {
        get {
            return technologyBaseGrowth + radScientistInfluence * config.radScientistMultiplier;
        }
    }

    public float interest;
    public float interestBaseGrowth;
    public float InterestGrowth {
        get {
            return interestBaseGrowth - conspiracyTheroistInfluence * config.conspiracyTheroistMultiplier;
        }
    }

    public float reputation;
    public float reputationBaseGrowth;
    public float ReputationGrowth {
        get {
            return reputationBaseGrowth - conspiracyTheroistInfluence * config.conspiracyTheroistMultiplier;
        }
    }
    
    [Header("Groups")]
    [Header("Antinatalists")]
    public bool antinatalistActive;
    public float antinatalistInfluence;
    public float antinatalistGrowth;
    [Header("RadScientists")]
    public bool radScientistActive;
    public float radScientistInfluence;
    public float radScientistGrowth;
    [Header("ConspiracyTheorists")]
    public bool conspiracyTheroistActive;
    public float conspiracyTheroistInfluence;
    public float conspiracyTheroistGrowth;

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
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        population += PopulationGrowth;
        inhabitability += InhabitabilityGrowth;
        technology += TechnologyGrowth;
        interest += InterestGrowth;
        reputation += ReputationGrowth;
        if (ShouldActivateAntinatalists()) ActivateAntinatalists();
        if (ShouldActivateRadScientists()) ActivateRadScientists();
        if (ShouldActivateConspiracyTheorists()) ActivateConspiracyTheorists(); 
    }

    public void Initialize() {
        antinatalistActive = false;
        radScientistActive = false;
        conspiracyTheroistActive = false;
        
        population = config.initPopulation;
        populationBaseGrowth = config.initPopulationGrowth;
        
        inhabitability = config.initInhabitability;
        inhabitabilityBaseGrowth = config.initInhabitabilityGrowth;
        
        technology = 0;
        technologyBaseGrowth = config.initTechnologyGrowth;

        interest = config.initInterest;
        interestBaseGrowth = config.initInterestGrowth;

        reputation = config.initReputation;
        reputationBaseGrowth = config.initReputationGrowth;
    }

    public void ActivateAntinatalists() {
        antinatalistActive = true;
        antinatalistGrowth = 1f;
        antinatalistInfluence = 10f;
    }

    public void ActivateRadScientists() {
        radScientistActive = true;
        radScientistGrowth = 1f;
        radScientistInfluence = 10f;
    }

    public void ActivateConspiracyTheorists() {
        conspiracyTheroistActive = true;
        conspiracyTheroistGrowth = 1f;
        conspiracyTheroistInfluence = 10f;
    }

    private bool ShouldActivateAntinatalists() {
        if (antinatalistActive) return false;
        float technologyPercentage = technology / config.technologyGoal;
        float timePercentage = gameTime / config.maxGameTime;
        float technologyLag = timePercentage - technologyPercentage;
        return inhabitability <= config.anitnatalistActiveInhabitability
            && technologyLag >= config.anitnatalistActiveTechnologyLag;
    }

    private bool ShouldActivateRadScientists() {
        if (radScientistActive) return false;
        return inhabitability <= config.radScientistActiveInhabitability;
    }

    private bool ShouldActivateConspiracyTheorists() {
        if (conspiracyTheroistActive) return false;
        return gameTime >= config.conspiracyActiveTime; 
    }
}
