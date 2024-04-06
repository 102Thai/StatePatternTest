using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem.SequencerCommands;
using PixelCrushers.DialogueSystem;
using System.Net;

public class SequencerCommandCameraMoveToObject: SequencerCommand
{
    private Vector3 cameraPos;
    private Transform targetObject;
    public void Awake()
    {
        cameraPos = Camera.main.transform.position;
        targetObject = GetSubject(listener.name);

        cameraPos = targetObject.position;
        cameraPos.z = -10;
        Camera.main.transform.position = cameraPos;
        Stop();
    }

}
