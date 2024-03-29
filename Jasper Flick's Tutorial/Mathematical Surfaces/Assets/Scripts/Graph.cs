using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField] private Transform pointPrefab;
    [SerializeField, Range(10, 100)] private int resolution;

    [SerializeField] FunctionLibary.FunctionName function;
    
    private Transform[] points;

    private void Awake()
    {
	    float step = 2f / resolution;
	    Vector3 scale = Vector3.one * step;
	    points = new Transform[resolution * resolution];
		for(int i = 0; i < points.Length; i++) {
			Transform point = points[i] = Instantiate(pointPrefab);
			point.localScale = scale;
			point.SetParent(transform, false);
	    }
    }

    private void Update()
    {
	    FunctionLibary.Function f = FunctionLibary.GetFunction(function);
	    float time = Time.time;
	    float step = 2f / resolution;
	    float v = 0.5f * step - 1.0f;
	    for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
		    if (x == resolution)
		    {
			    x = 0;
			    z += 1;
			    v = (z + 0.5f) * step - 1.0f;
		    }

		    float u = (x + .5f) * step - 1f;
		    points[i].localPosition = f(u, v, time);
	    }
    }
}
