using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class HealthFixedArea : MonoBehaviour
{
    [SerializeField] private Vector2 margin = new Vector2(10f, 10f); // Margin for the health bar
    void Awake(){
        RectTransform rt = (RectTransform)transform;

        // anchor the pivot
        rt.anchorMin = rt.anchorMax = new Vector2(0f, 0f); 
        rt.pivot = new Vector2(0f, 1f); 
        // set offset the position
        rt.anchoredPosition = new Vector2(margin.x, -margin.y); 

    }
    private void OnRectTransformDimensionsChange(){
        ((RectTransform)transform).anchoredPosition =
            new Vector2(margin.x, -margin.y);
    }
}
