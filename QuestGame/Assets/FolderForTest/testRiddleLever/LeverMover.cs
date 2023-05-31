using UnityEngine;

public class LeverMover : MonoBehaviour
{
    private float speedDrag = 100f;

    private void OnMouseDrag()
    {
        Debug.Log("MousePosition =" + GetMousePosition());
        Debug.Log("transform.position =" + transform.position);
        transform.position = Vector3.MoveTowards(transform.position, GetMousePosition(), speedDrag * Time.deltaTime);
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        return mousePosition;
    }
}
