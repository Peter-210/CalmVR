using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera Cam;
    public SteamVR_Input_Sources TargetSource;
    public SteamVR_Action_Boolean ClickAction;

    private GameObject CurrentObject = null;
    private PointerEventData Data = null;

    protected override void Awake()
    {
        base.Awake();

        Data = new PointerEventData(eventSystem);

    }

    public override void Process()
    {
        Data.Reset();
        Data.position = new Vector2(Cam.pixelWidth / 2, Cam.pixelHeight / 2);

        eventSystem.RaycastAll(Data, m_RaycastResultCache);
        Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        CurrentObject = Data.pointerCurrentRaycast.gameObject;

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(Data, CurrentObject);
        if (ClickAction.GetStateDown(TargetSource))
        {
            ProcessPress(Data);
        }
        if (ClickAction.GetStateDown(TargetSource))
        {
            ProcessPress(Data);
        }
    }

    public PointerEventData GetData()
    {
        return Data;
    }

    private void ProcessPress(PointerEventData data)
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(CurrentObject, data, ExecuteEvents.pointerDownHandler);
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);
        }
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = CurrentObject;
    }
    private void ProcessRelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);
        if (data.pointerPress == pointerUpHandler) 
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }
        eventSystem.SetSelectedGameObject(null);
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
