using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider2D;
    private List<Vector2> tempPoints;
    public float amplitude = 10f;
    public float wavelength = 100f;
    private Vector2 position;
    public float offsetX = 0f;
    private GameObject playerPos;

    void Start()
    {   
        tempPoints = new List<Vector2>();
        
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        position = new Vector2(0, 0);
        playerPos = GameObject.FindGameObjectWithTag("Player");

    }

    
    void Update()
    {
        offsetX = playerPos.transform.position.x;
        DrawSineWave(position, amplitude, wavelength);
        
    }

    void DrawSineWave(Vector3 startPoint, float amplitude, float wavelength)
    {
        tempPoints.Clear();
        float x = 0f;
        float y = 0f;
        //float k = 2 * Mathf.PI / wavelength;
        lineRenderer.positionCount = 50;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            x = i * 0.9f + offsetX;
            y = amplitude * Mathf.PerlinNoise(x / wavelength, y / wavelength) - i * 0.3f ;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0) + startPoint);
            tempPoints.Add(new Vector3(x , y, 0) + startPoint);
        }
        edgeCollider2D.points = tempPoints.ToArray();
        
    }



}
