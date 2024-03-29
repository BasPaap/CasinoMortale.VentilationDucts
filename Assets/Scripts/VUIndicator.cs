using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class VUIndicator : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] private float level;
    [SerializeField] private Sprite[] sprites;
    
    private Image image;
    private float perlinYAxis;
    private const float fluctuationSpeed = 2.0f;

    public float Level
    {
        get => level;
        set { level = Mathf.Clamp01(value); }
    }

    private void Awake()
    {
        perlinYAxis = (float)transform.GetSiblingIndex();
        image = GetComponent<Image>();
        image.color = Color.clear;
    }

    public void Clear()
    {
        Level = 0;

        if (image != null)
        {
            image.color = Color.clear;
        }    
    }

    private void Update()
    {
        var noise = Mathf.RoundToInt((2 - (Mathf.PerlinNoise(Time.time * fluctuationSpeed, perlinYAxis) * 4)));
        
        var spriteIndex = (int)Mathf.Lerp(0, sprites.Length, level);
        spriteIndex = Mathf.Clamp(spriteIndex + noise, 0, sprites.Length);

        if (spriteIndex == 0)
        {
            image.color = Color.clear;
        }
        else
        {
            image.color = Color.white;
            image.sprite = sprites[spriteIndex -1];
        }        
    }
}
