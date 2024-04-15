using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerLogic : MonoBehaviour
{
    public float DefaultLength = 5.0f;
    public GameObject DotObject;
    public VRInputModule InputModule;

    private LineRenderer LineRender = null;

    private void Awake()
    {
        LineRender = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        PointerEventData data = InputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? DefaultLength : data.pointerCurrentRaycast.distance;

        RaycastHit hit = CreateRaycast(targetLength);
        Vector3 endPosition = transform.position + (transform.forward * targetLength);
        if (hit.collider != null)
        {
            endPosition = hit.point;
        }
        DotObject.transform.position = endPosition;
        LineRender.SetPosition(0, transform.position);
        LineRender.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, DefaultLength);
        return hit;
    }
}
