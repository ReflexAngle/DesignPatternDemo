using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderQueue : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.material.renderQueue = 4000;
    }
}
