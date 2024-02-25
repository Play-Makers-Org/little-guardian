using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public bool isFlip = false;
    private float angleOffset = 4f;

    public Transform _healthBarTransform;

    private void Start()
    {
        _healthBarTransform = GameObject.Find(GameObjectNameConstants.healthBar).transform;
    }

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
            _healthBarTransform.rotation = Quaternion.Euler(new Vector3());
        }
        else
        {
            angle += angleOffset;
            transform.rotation = Quaternion.Euler(180f, 0f, angle * -1);
            _healthBarTransform.rotation = Quaternion.Euler(new Vector3(180f, 0f));
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