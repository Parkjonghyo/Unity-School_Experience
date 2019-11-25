using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class HoldingSpace : MonoBehaviour
{

    private Transform _holdingSpace;
    private Transform _transform;
    private TrailRenderer _trailRenderer;
    public Material shader;

    // Start is called before the first frame update
    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _transform = GetComponent<Transform>();
        _holdingSpace = Camera.main.transform.GetChild(0).GetComponent<Transform>();
    }

    private void Update()
    {
        _trailRenderer.startWidth = 0;
        if(Input.GetMouseButton(0)){trace();}
    }

    public void trace()
    {
        _transform.position = _holdingSpace.position;
    }
}
