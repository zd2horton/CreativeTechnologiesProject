using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextGen
{

    public static Texture2D textColourMap(Color[] colourMap, int cmWidth, int cmheight)
    {
        Texture2D texture = new Texture2D(cmWidth, cmheight);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D textHeightMap(float[,] heightMap)
    {
        int displayWidth = heightMap.GetLength(0);
        int displayHeight = heightMap.GetLength(1);
        Color[] colourMap = new Color[displayWidth * displayHeight];

        for (int i = 0; i < displayHeight; i++)
        {
            for (int j = 0; j < displayWidth; j++)
            {
                colourMap[i * displayWidth + j] = Color.Lerp(Color.black, Color.white, heightMap[j, i]);
            }
        }
        return textColourMap(colourMap, displayWidth, displayHeight);
    }
}
