using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 参考にしたサイト
// https://unity-yuji.xyz/player-follow-camera-smoothness/

public class CameraController : MonoBehaviour
{
    Transform cameraTrans;
    [SerializeField]
    Transform playerTrans;

    [SerializeField]
    Vector3 cameraVec;
    [SerializeField]
    Vector3 cameraRot;

    private void Awake()
    {
        cameraTrans = transform;
        cameraTrans.rotation = Quaternion.Euler(cameraRot);
    }

    private void LateUpdate()
    {
        cameraTrans = transform;
        cameraTrans.rotation = Quaternion.Euler(cameraRot);
        cameraTrans.position = playerTrans.position + cameraVec;
    }
}
