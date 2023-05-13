using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PartOfPuzzle : MonoBehaviour
{
    private Ray ray;
    [SerializeField]
    private LayerMask wayLayerMask;
    [SerializeField]
    private LayerMask partLayerMask;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private Transform correctPoint;
    private bool isDrag;
    [SerializeField]
    private PieceOfGearPuzzle pieceOfGearPuzzle;
    public bool IsCorrect = false;


    private void Update()
    {
        Ray();
        Interactive();
    }

    private void CheckPlace()
    {
        for (int i = 0; i < points.Length; i++)
            if (Vector3.Distance(transform.position, points[i].position) <= 0.03f)
            {
                Debug.Log(Vector3.Distance(transform.position, points[i].position));
                transform.position = points[i].position;
                if (points[i] == correctPoint)
                {
                    var partGearItem = Inventory.inventory.Find(part => part is PieceOfGear);
                    partGearItem.Drop();
                    Destroy(partGearItem.gameObject);

                    IsCorrect = true;
                    transform.gameObject.layer = 7;
                    transform.GetComponent<Collider>().enabled = false;
                    pieceOfGearPuzzle.PartsOfGear.Remove(transform);
                    pieceOfGearPuzzle.SolvedParts.Add(transform);
                    pieceOfGearPuzzle.CheckWin();
                }
            }
    }

    private void Ray()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
    private void Interactive()
    {
        if (isDrag)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, wayLayerMask))
            {
                transform.position = hit.point;
            }
        }
    }

    private void OnMouseUp()
    {
        isDrag = false;
        CheckPlace();
    }

    private void OnMouseDown()
    {
        isDrag = true;
    }
}
