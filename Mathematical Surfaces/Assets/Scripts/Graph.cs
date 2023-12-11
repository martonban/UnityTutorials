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
	    Vector3 position = Vector3.zero;
	    Vector3 scale = Vector3.one * step;
	    points = new Transform[resolution * resolution];
		for(int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
			if (x == resolution) {
				x = 0;
				z += 1;
			}
			Transform point = points[i] = Instantiate(pointPrefab);
		    position.x = (x + 0.5f) * step - 1f;
		    position.y = position.x * position.x * position.x;
		    position.z = (z + 0.5f) * step - 1f;
		    point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);
	    }
    }

    private void Update()
    {
	    FunctionLibary.Function f = FunctionLibary.GetFunction(function);
	    float time = Time.time;
	    for (int i = 0; i < points.Length; i++) {
		    Transform point = points[i];
		    Vector3 position = point.localPosition;
		    position.y = f(position.x, position.z, time);
		    point.localPosition = position;
	    }
    }
}
