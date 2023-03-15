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
    private Vector3 mousePositionInStart;

    private void OnMouseEnter()
    {
        mousePositionInStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
    }
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance) - mousePositionInStart; ; // ���������� ������������� ���������� ���� �� ���� � ������
        //Vector3 objPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���������� - ������� �������������� ���������� � ������������ ����
        Move(mousePosition);
    }

    private void Move(Vector3 objPosition)
    {
        var position = transform.position;
        Debug.Log("�����" + transform.localPosition);
        Debug.Log("����" + objPosition);
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
        {
            IsRightCollision = value;
            Debug.Log(1);
        }
        if (side == Sides.Left)
        {
            IsLeftCollision = value;
            Debug.Log(2);
        }
        if (side == Sides.Top)
        {
            IsTopCollision = value;
            Debug.Log(3);
        }
        if (side == Sides.Bot)
        {
            IsBotCollision = value;
            Debug.Log(4);
        }
    }
}
