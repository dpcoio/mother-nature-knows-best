using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StrikeTarget(float power) {

    }

    public virtual void UpdateStayEffect() {

    }
}
