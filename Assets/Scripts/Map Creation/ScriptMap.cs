using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScriptMap
{
    public static float[,] NoiseMapGen(int mWidth, int mHeight, int seed,
                           int octaves, float lacunarity, float persistance,
                           float scale, Vector2 offset)
    {
        System.Random psuedoRNG = new System.Random(seed);

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float[,] noiseMap = new float[mWidth, mHeight];
        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;
        float halfW = mWidth / 2.0f;
        float halfH = mHeight / 2.0f;

        Vector2[] octaveOffset = new Vector2[octaves];

        for (int l = 0; l < octaves; l++)
        {
            float xOffset = psuedoRNG.Next(-125000, 125000) + offset.x;
            float yOffset = psuedoRNG.Next(-125000, 125000) + offset.y;
            octaveOffset[l] = new Vector2(xOffset, yOffset);
        }

        for (int i = 0; i < mHeight; i++)
        {
            for (int j = 0; j < mWidth; j++)
            {
                float amplitude = 1.0f;
                float frequency = 1.0f;
                float noiseHeight = 0.0f;

                for (int k = 0; k < octaves; k++)
                {
                    float xSample = (j - halfW) / scale * frequency + octaveOffset[k].x;
                    float ySample = (i - halfH) / scale * frequency + octaveOffset[k].y;
                    float perlin = Mathf.PerlinNoise(xSample, ySample) * 2 - 1;

                    noiseHeight += perlin * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxHeight)
                {
                    maxHeight = noiseHeight;
                }

                else if (noiseHeight < minHeight)
                {
                    minHeight = noiseHeight;
                }
                noiseMap[j, i] = noiseHeight;
            }
        }

        for (int i = 0; i < mHeight; i++)
        {
            for (int j = 0; j < mWidth; j++)
            {
                noiseMap[j, i] = Mathf.InverseLerp(minHeight, maxHeight, noiseMap[j, i]);
            }
        }

        return noiseMap;
    }
}
