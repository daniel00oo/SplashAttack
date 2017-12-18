using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {
    private float x; 
	private Vector3 ls;

    // Use this for initialization
    void Start()
    {
        x = transform.localScale.x;
        ls = transform.localScale;
    }

    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

       
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        ls.x = x;
        transform.localScale = ls;
       
    }
}

