using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    [SerializeField] private Texture2D highlightedTexture;
    private Texture normalTexture;
    private MeshRenderer meshRenderer;
    
    public int Column { get; set; }
    public int Row { get; set; }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalTexture = meshRenderer.material.mainTexture;
    }

    internal void SetHighlight(bool isHighlighted)
    {
        meshRenderer.material.mainTexture = isHighlighted ? highlightedTexture : normalTexture;
    }    
}
