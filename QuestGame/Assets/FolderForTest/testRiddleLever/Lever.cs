using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public float distance = 10f;
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float eps = 0.1f;
    private bool IsTopCollision;
    private bool IsBotCollision;
    private bool IsRightCollision;
    private bool IsLeftCollision;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        Move(mousePosition);
    }

    private void Move(Vector3 objPosition)
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);
        if (objPosition.x - position.x > eps && !IsRightCollision)
            transform.localPosition += new Vector3(speed * Time.deltaTime, 0);
        else if (objPosition.x - position.x < -eps && !IsLeftCollision)
            transform.localPosition -= new Vector3(speed * Time.deltaTime, 0);
        else if (objPosition.y - position.y > eps && !IsTopCollision)
            transform.localPosition += new Vector3(0, speed * Time.deltaTime);
        else if (objPosition.y - position.y < -eps && !IsBotCollision)
            transform.localPosition -= new Vector3(0, speed * Time.deltaTime);
    }

    public void SetCollision(Sides side, bool value)
    {
        if (side == Sides.Right)
            IsRightCollision = value;
        if (side == Sides.Left)
            IsLeftCollision = value;
        if (side == Sides.Top)
            IsTopCollision = value;
        if (side == Sides.Bot)
            IsBotCollision = value;
    }
}
