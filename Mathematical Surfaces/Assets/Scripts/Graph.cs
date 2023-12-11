using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField] private Transform pointPrefab;
    [SerializeField, Range(10, 100)] private int resolution;

    [SerializeField, Range(0, 2)]
    int function;
    
    private Transform[] points;

    private void Awake()
    {
	    float step = 2f / resolution;
	    Vector3 position = Vector3.zero;
	    Vector3 scale = Vector3.one * step;
	    points = new Transform[resolution];
		for(int i = 0; i < points.Length; i++) {
			Transform point = points[i] = Instantiate(pointPrefab);
		    position.x = (i + 0.5f) * step - 1f;
		    position.y = position.x * position.x * position.x;
		    point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);
	    }
    }

    private void Update()
    {
	    float time = Time.time;
	    for (int i = 0; i < points.Length; i++) {
		    Transform point = points[i];
		    Vector3 position = point.localPosition;
		    if (function == 0)
		    {
			    position.y = FunctionLibary.Wave(position.x, time);
		    } else if (function == 1)
		    {
			    position.y = FunctionLibary.MultiWave(position.x, time);
		    }
		    else if (function == 2)
		    {
			    position.y = FunctionLibary.Ripple(position.x, time);
		    }
		    point.localPosition = position;
	    }
    }
}
