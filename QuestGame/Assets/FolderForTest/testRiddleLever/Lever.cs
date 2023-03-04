using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool CanMove;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField]
    private LayerMask wayLayerMask;

    private void Update()
    {
        Ray();
        Interactive();
    }

    private void Ray()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);
    }
    private void Interactive()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, wayLayerMask) && CanMove && Input.GetMouseButton(0))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.05f, wayLayerMask);
            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject == hit.collider.gameObject)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime);
                    }
                }
            }
        }
    }
}