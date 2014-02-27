using UnityEngine;
using System.Collections.Generic;


public class A : MonoBehaviour {

	List<Vector3> linePoints = new List<Vector3>();
	LineRenderer lineRenderer;
	public float startWidth = 1.0f;
	public float endWidth = 1.0f;
	public float threshold = 0.001f;
	Camera thisCamera;
	int lineCount = 0;
	
	Vector3 lastPos = Vector3.one * float.MaxValue;

	// Use this for initialization
	void Start () {
		thisCamera = Camera.main;
		lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDrag(){
		Debug.Log("DRAG");
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = thisCamera.nearClipPlane;
		Vector3 mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);
		
		float dist = Vector3.Distance(lastPos, mouseWorld);
		
		if(dist <= threshold)
			return;
		
		lastPos = mouseWorld;
		
		if(linePoints == null)
			linePoints = new List<Vector3>();
		
		linePoints.Add(mouseWorld);
		
		UpdateLine();

//		Vector2 p = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
//		
//		//tab.Add(p);
//
//		Debug.Log ("click dentro de la A");
	}

	void UpdateLine()
	{
		lineRenderer.SetWidth(startWidth, endWidth);
		lineRenderer.SetVertexCount(linePoints.Count);
		
		for(int i = lineCount; i < linePoints.Count; i++)
		{
			lineRenderer.SetPosition(i, linePoints[i]);
		}
		lineCount = linePoints.Count;
	}
}
