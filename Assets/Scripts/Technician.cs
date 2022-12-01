using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Technician : Target
{
    public override void StrikeTarget(float power)
    {
        GameManager.Instance.technology -= 10;
    }
}