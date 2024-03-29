using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] private GameObject straightDuctPrefab;
    [SerializeField] private GameObject cornerDuctPrefab;
    [SerializeField] private GameObject threeWayDuctPrefab;
    [SerializeField] private GameObject fourWayDuctPrefab;
    [SerializeField] private GameObject rampDuctPrefab;
    [SerializeField] private GameObject grillDuctPrefab;
    [SerializeField] private GameObject soundPrefab;
    [SerializeField] private GameObject startPositionPrefab;
    [SerializeField] private GameObject clearPrefab;

    public static TileFactory Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public GameObject GetTilePrefabByType<T>(T tileType) where T : Enum
    {
        if (tileType is DuctType ductType)
        {
            switch (ductType)
            {
                case DuctType.Straight:
                    return straightDuctPrefab;
                case DuctType.Corner:
                    return cornerDuctPrefab;
                case DuctType.ThreeWayCrossing:
                    return threeWayDuctPrefab;
                case DuctType.FourWayCrossing:
                    return fourWayDuctPrefab;
                case DuctType.Grill:
                    return grillDuctPrefab;
                case DuctType.Ramp:
                    return rampDuctPrefab;
                case DuctType.None:
                default:
                    return null;
            };
        }

        return null;
    }

    public GameObject GetTilePrefab<T>(T tileData) where T : TileData
    {
        if (tileData is DuctTileData ductTileData)
        {
            return GetTilePrefabByType(ductTileData.Type);
        }
        else if (tileData is SoundTileData)
        {
            return soundPrefab;
        }
        else if (tileData is StartPositionTileData)
        {
            return startPositionPrefab;
        }

        return null;
    }    

    public GameObject GetSoundTilePrefab()
    {
        return soundPrefab;
    }

    public GameObject GetStartPositionPrefab()
    {
        return startPositionPrefab;
    }

    public GameObject GetClearPrefab()
    {
        return clearPrefab;
    }
}