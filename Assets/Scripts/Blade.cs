using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private bool slicing;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    public float minSliceVelocity = 0.01f;
    public float sliceForce = 5f;

    public Vector3 direction { get; private set; }

    private void Awake()

    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartSlicing();
        } else if (Input.GetMouseButtonUp(0)) {
            StopSlicing();
        } else if (slicing) {
            continueSlicing();
        }
    }

    private void StartSlicing()
    {
        Vector3 newPositon = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPositon.z = 0f;
        transform.position = newPositon;
        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }

    private void StopSlicing()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void continueSlicing()
    {
        Vector3 newPositon = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPositon.z = 0f;
        direction = newPositon - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;
        transform.position = newPositon;
    }
}