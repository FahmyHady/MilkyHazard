using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentControl : MonoBehaviour
{
    [SerializeField] float hAngleLimit;
    [SerializeField] float vAngleLimit;
    Vector3 mousePos;
    Camera myCamera;
    private void Start()
    {
        myCamera = Camera.main;
    }
    private void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = myCamera.ScreenToViewportPoint(mousePos);
        transform.localEulerAngles = new Vector3((vAngleLimit / 0.5f) * ( 0.5f-mousePos.y), (hAngleLimit/0.5f)*(mousePos.x-0.5f), 0);
    }
}
