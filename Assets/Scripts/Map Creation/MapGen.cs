using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public enum DrawMode { noiseMap, colourMap };
    public DrawMode drawMode;

    public int mWidth, mHeight, octaves, seed;
    public float scale, lacunarity;
    [Range(0, 1)]
    public float persistance;
    public bool updating;
    public Vector2 offset;

    public TerrainType[] terrains;
    [System.Serializable]
    public struct TerrainType
    {
        public string terrainName;
        public float terrainHeight;
        public Color terrainColour;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void DrawnMapGeneration()
    {
        Color[] colourMap = new Color[mWidth * mHeight];
        float[,] noiseMap = ScriptMap.NoiseMapGen(mWidth, mHeight, seed, octaves,
                            lacunarity, persistance, scale, offset);

        for (int i = 0; i < mHeight; i++)
        {
            for (int j = 0; j < mWidth; j++)
            {
                float currentHeight = noiseMap[j, i];

                for (int k = 0; k < terrains.Length; k++)
                {
                    if (currentHeight <= terrains[k].terrainHeight)
                    {
                        colourMap[i * mWidth + j] = terrains[k].terrainColour;
                        break;
                    }
                }
            }
        }

        MapDisplayGen mapCanvas = FindObjectOfType<MapDisplayGen>();

        if (drawMode == DrawMode.noiseMap)
        {
            mapCanvas.DrawTexMap(TextGen.textHeightMap(noiseMap));
        }

        else if (drawMode == DrawMode.colourMap)
        {
            mapCanvas.DrawTexMap(TextGen.textColourMap(colourMap, mWidth, mHeight));
        }
    }

    private void OnValidate()
    {
        if (mWidth < 1)
        {
            mWidth = 1;
        }

        if (mHeight < 1)
        {
            mHeight = 1;
        }

        if (lacunarity < 1)
        {
            lacunarity = 1;
        }

        if (octaves < 0)
        {
            octaves = 0;
        }
    }
}
