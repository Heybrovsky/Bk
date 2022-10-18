using System.Collections.Generic;
using UnityEngine;

public class BK_Curve : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField, Min(1)] private int length = 5;
    [SerializeField, Min(1)] private int resolution = 1;

    private List<Vector3> points = new List<Vector3>();

    [Header("References")]
    [SerializeField] private Transform pointToFollow = null;

    [Header("Components")]
    private LineRenderer bodyLineRenderer = null;

    private void Awake()
    {
        bodyLineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        bodyLineRenderer.positionCount = length * resolution;

        points.Add(pointToFollow.position);
        for (int i = 1; i < bodyLineRenderer.positionCount; i++)
        {
            points.Add(points[i - 1] - pointToFollow.right * 1 / (float)resolution);
            bodyLineRenderer.SetPosition(i, points[i]);
        }
    }

    private void Update()
    {
        //Gizmos.DrawLine(bodyLineRenderer);
        if (points[0] != pointToFollow.position)
        {
            points[0] = pointToFollow.position;
            bodyLineRenderer.SetPosition(0, points[0]);

            for (int i = 1; i < points.Count; i++)
            {
                points[i] = points[i - 1] - (points[i - 1] - points[i]).normalized / resolution;
                bodyLineRenderer.SetPosition(i, points[i]);
            }
        }
    }
}
