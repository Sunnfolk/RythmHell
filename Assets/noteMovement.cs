using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteMovement : MonoBehaviour
{
    public float NoteSpeed { private get; set; }

    private void Update()
    {
        transform.Translate(NoteSpeed * Time.deltaTime * Vector3.down);
    }
}