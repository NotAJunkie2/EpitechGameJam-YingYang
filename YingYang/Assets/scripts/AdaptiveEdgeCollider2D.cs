using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveEdgeCollider2D : MonoBehaviour
{
    public bool isTrigger = false;

    void Awake() {
        // Get/create Polygon collider
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        if (collider == null) {
            collider = gameObject.AddComponent<PolygonCollider2D>();
        }

        // Create a list of points from Polygon collider 2D
        List<Vector2> points = new List<Vector2>(collider.points);
        points.Add(points[0]);

        // Init an Edge collider 2D using points from Polygon collider 2D
        EdgeCollider2D edge = gameObject.AddComponent<EdgeCollider2D>();
        edge.points = points.ToArray();

        if (this.isTrigger) {
            edge.isTrigger = true;
        }

        // Destroy Polygon collider 2D
        Destroy(collider);
    }
}
