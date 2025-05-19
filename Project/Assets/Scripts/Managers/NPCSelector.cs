using UnityEngine;

public class NPCSelector : MonoBehaviour
{
    private bool isDragging = false;
    private float fixedY;
    private Vector3 targetPosition;
    public float smoothSpeed = 10f;

    private Camera cam;
    private Plane groundPlane;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        NPCManager.Instance.SetSelected(gameObject);
        isDragging = true;
        fixedY = transform.position.y;
        groundPlane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging && Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                targetPosition = new Vector3(hitPoint.x, fixedY, hitPoint.z);
            }
        }

        if (isDragging)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothSpeed);
        }
    }
}
