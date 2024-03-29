﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform focus;
    public float smoothTime = 2;

    Vector3 offset;

    void Awake()
    {
        offset = focus.position - transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, focus.position - offset, Time.deltaTime * smoothTime);
    }
}
