using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameConfig
{
    [Header("Basic")]
    public float maxGameTime;
    [Header("Population")]
    public float initPopulation;
    public float initPopulationGrowth;
    [Header("Inhabitability")]
    public float initInhabitability;
    public float initInhabitabilityGrowth;
    [Header("Technology")]
    public float technologyGoal;
    public float initTechnologyGrowth;
    [Header("Interest")]
    public float initInterest;
    public float initInterestGrowth;
    [Header("reputation")]
    public float initReputation;
    public float initReputationGrowth;
    [Header("Antinatalists")]
    public float antinatalistMultiplier;
    public float anitnatalistActiveInhabitability;
    public float anitnatalistActiveTechnologyLag;
    [Header("RadScientists")]
    public float radScientistMultiplier;
    public float radScientistActiveInhabitability;
    [Header("ConspiracyTheorists")]
    public float conspiracyTheroistMultiplier;
    public float conspiracyActiveTime;
}
