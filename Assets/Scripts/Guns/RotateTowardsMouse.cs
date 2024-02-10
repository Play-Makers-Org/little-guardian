using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public bool isFlip = false;
    private float angleOffset = 4f;

    // Update is called once per frame
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.root.position).normalized;
        SetIsFlip(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (!isFlip)
        {
            angle -= angleOffset;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            angle += angleOffset;
            transform.rotation = Quaternion.Euler(180f, 0f, angle * -1);
        }
    }

    private void SetIsFlip(Vector2 direction)
    {
        var directionX = direction.x;
        if (directionX > 0)
        {
            isFlip = false;
        }
        else
        {
            isFlip = true;
        }
    }
}