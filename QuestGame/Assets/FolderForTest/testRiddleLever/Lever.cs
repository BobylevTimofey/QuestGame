using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public float distance = 10f;
    private float speed = 7f;
    private float eps = 0.1f;
    private bool IsTopCollision;
    private bool IsBotCollision;
    private bool IsRightCollision;
    private bool IsLeftCollision;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        Move(objPosition);
    }

    private void Move(Vector3 objPosition)
    {
        var possition = transform.position;
        if (objPosition.x - possition.x > eps && !IsRightCollision)
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        else if (objPosition.x - possition.x < -eps && !IsLeftCollision)
            transform.position -= new Vector3(speed * Time.deltaTime, 0);
        else if (objPosition.y - possition.y > eps && !IsTopCollision)
            transform.position += new Vector3(0, speed * Time.deltaTime);
        else if (objPosition.y - possition.y < -eps && !IsBotCollision)
            transform.position -= new Vector3(0, speed * Time.deltaTime);
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
