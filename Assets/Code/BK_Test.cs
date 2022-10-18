using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BK_Test : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform wtf = null;
    [SerializeField] private LineRenderer bodyLineRenderer = null;
    [SerializeField] private PolygonCollider2D bodyPolygonCollider2D = null;

    private void Update()
    {
        Vector2[] _points = new Vector2[2 * bodyLineRenderer.positionCount];

        Debug.Log($"{Vector2.Perpendicular(wtf.right)} :: {Vector2.Perpendicular(wtf.right)}");
        _points[0] = Vector2.zero + 0.5f * bodyLineRenderer.startWidth * Vector2.Perpendicular(wtf.right);

        for (int i = 1; i < bodyLineRenderer.positionCount; i++)
        {
            _points[i] = transform.InverseTransformPoint(bodyLineRenderer.GetPosition(i));
            _points[i] += 0.5f * bodyLineRenderer.startWidth * Vector2.Perpendicular((bodyLineRenderer.GetPosition(i - 1) - bodyLineRenderer.GetPosition(i)).normalized);
        }

        for (int i = 0; i < bodyLineRenderer.positionCount - 1; i++)
        {
            _points[i + bodyLineRenderer.positionCount] = transform.InverseTransformPoint(bodyLineRenderer.GetPosition(bodyLineRenderer.positionCount - 1 - i));
            _points[i + bodyLineRenderer.positionCount] -= 0.5f * bodyLineRenderer.startWidth * Vector2.Perpendicular((bodyLineRenderer.GetPosition(bodyLineRenderer.positionCount - 2 - i) - bodyLineRenderer.GetPosition(bodyLineRenderer.positionCount - 1 - i)).normalized);
        }

        _points[_points.Length - 1] = Vector2.zero - 0.5f * bodyLineRenderer.startWidth * Vector2.Perpendicular(wtf.right);

        bodyPolygonCollider2D.SetPath(0, _points);
    }
}
