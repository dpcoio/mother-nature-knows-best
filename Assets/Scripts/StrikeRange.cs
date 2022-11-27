using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeRange : MonoBehaviour
{
    public float radius;
    public GameObject display;

    public bool IsInRange(Target target) {
        return (target.transform.position - transform.position).magnitude <= radius;
    }
    // Start is called before the first frame update
    void Start()
    {
        display.transform.localScale = Vector2.one * radius;
        display.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
