using UnityEngine;

public class GeneralConstants : MonoBehaviour
{
    private static readonly Vector2 mapMin = new Vector2(-22.7f, -14.5f);
    private static readonly Vector2 mapMax = new Vector2(30.5f, 14.5f);

    public static readonly Boundary mapBoundaries = new Boundary()
    {
        xmin = mapMin.x,
        ymin = mapMin.y,
        xmax = mapMax.x,
        ymax = mapMax.y,
    };
}