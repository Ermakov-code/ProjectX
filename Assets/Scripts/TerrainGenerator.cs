using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;

    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        offsetX = Random.Range(0, 9999f);
        offsetY = Random.Range(0, 9999f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, 0.3f);
        terrainData.SetHeights(0, 0, GenerateHeight());
        return terrainData;
    }

    float[,] GenerateHeight()
    {
        float[,] heights = new float[width,height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeigth(x, y);
            }
        }

        return heights;
    }

    float CalculateHeigth(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
