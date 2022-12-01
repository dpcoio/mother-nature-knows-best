using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StrikeRange : MonoBehaviour
{
    public GameObject display;
    public CircleCollider2D rangeCollider;

    public bool TargetIsInRange(Target target) {
        return rangeCollider.bounds.Contains(target.transform.position);
    }

    public void Initialize(float radius) {

        transform.localScale = Vector2.one * radius;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;
    }
}
