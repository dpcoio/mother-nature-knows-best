using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    private PolygonCollider2D areaCollider;
    // Start is called before the first frame update
    void Start()
    {
        areaCollider = gameObject.AddComponent<PolygonCollider2D>();
        areaCollider.isTrigger = true;
    }

    public bool IsPointInCollider(Vector2 point) {
        return areaCollider.bounds.Contains(point);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
