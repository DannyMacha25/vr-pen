using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class DrawLineManager : MonoBehaviour
{
    public SteamVR_Input_Sources trackedObj;
    public SteamVR_Action_Boolean triggerClicked;
    public SteamVR_Action_Boolean triggerTouch;
    public SteamVR_Action_Pose controllerPose;

    public GameObject vrController;
    public Material lMat;
    public float width;

    //private GraphicsLineRenderer currLine;
    private Unity.XRTools.Rendering.XRLineRenderer currLine;
    private bool triggerHeld = false;
    private int numClicks = 0;
    private Vector3 prevPoint;
    void Start()
    {

    }
    private void Update()
    {
        //Debug.Log(controllerPose.localPosition);
        if(triggerClicked.GetStateDown(trackedObj))
        {
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();            
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<Unity.XRTools.Rendering.XRLineRenderer>();
            currLine.SetTotalWidth(width);
            currLine.material = lMat;
            numClicks = 0;
            triggerHeld = true;
            prevPoint = Vector3.zero;
        } else if (triggerHeld)
        {

            currLine.SetVertexCount(numClicks + 1);
            currLine.SetPosition(numClicks, controllerPose.GetLocalPosition(trackedObj));

            numClicks++;
        }

        if(triggerClicked.GetStateUp(trackedObj))
        {
            triggerHeld = false;
        }

    }

}
