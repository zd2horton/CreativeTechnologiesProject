using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplayGen : MonoBehaviour
{
    public Renderer textureNoiseRenderer;

    void Start()
    {

    }

    void Update()
    {

    }

    public void DrawTexMap(Texture2D texture)
    {
        textureNoiseRenderer.sharedMaterial.mainTexture = texture;
        textureNoiseRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }
}
