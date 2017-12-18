using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float backgroundSize;
    public float parallaxSpeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone=10;
    private int leftIndex;
    private int rightIndex;
    private float y;
   
    private float lastCameraX;
    private void Start()
    {
         //y = transform.position.y;
       
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i]=transform.GetChild(i);
        
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void FixedUpdate()
    {
        float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += new Vector3(1, 0, 0) * (deltaX * parallaxSpeed);

		lastCameraX = cameraTransform.position.x;
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            ScrollRight();

    }
   	private void ScrollLeft() { // if we scroll too far left side 

 
		layers[rightIndex].position = new Vector3(0, layers[leftIndex].position.y, layers[leftIndex].position.z) + Vector3.right * (layers[leftIndex].position.x - backgroundSize); //changed position
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }


    private void ScrollRight() { // if we scroll too far right side 

     
		layers[leftIndex].position = new Vector3(0, layers[leftIndex].position.y, layers[leftIndex].position.z) + Vector3.right * (layers[rightIndex].position.x + backgroundSize); //changed position
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex  = 0;
    }


}



