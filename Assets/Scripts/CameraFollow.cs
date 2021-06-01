using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Transform cameraHolder;
    int offset = 2;

    public delegate void PlayerLeftScreen();
    public event PlayerLeftScreen OnPlayerLefScreen;

    void FixedUpdate()
    {
        if (player.transform.position.y + offset > cameraHolder.transform.position.y)
            cameraHolder.transform.position = new Vector3(0, player.transform.position.y + offset, cameraHolder.transform.position.z);
        else if (player.transform.position.y < cameraHolder.transform.position.y - 5)
        {
            //Debug.Log("Player out of Screen!");
            OnPlayerLefScreen();
        }
    }

    private void OnEnable()
    {
        player.OnPlayerBoosted += ShakeCamera;
    }

    private void OnDisable()
    {
        player.OnPlayerBoosted -= ShakeCamera;
    }

    void ShakeCamera(float shakeTimer)
    {
        Camera.main.DOComplete();
        Camera.main.transform.DOShakePosition(shakeTimer, .25f, 50, 90, false);
        //Debug.Log("Shaking Camera...");
    }
}
