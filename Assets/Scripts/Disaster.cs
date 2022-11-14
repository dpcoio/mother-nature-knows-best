using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MNKB/Disaster")]
public class Disaster : ScriptableObject
{
    public Sprite menuIcon;
    public int radius;
    public float coolDown;
    public float maxPower;
    public float minPower;
}
