using UnityEngine;
using System.Collections.Generic;


public class Character : MonoBehaviour {

	List<Vector3> linePoints = new List<Vector3>();
	LineRenderer lineRenderer;
	public float startWidth = 1.0f;
	public float endWidth = 1.0f;
	public float threshold = 0.001f;
	Camera thisCamera;
	int lineCount = 0;
	private GameObject lastLine; 
	
	Vector3 lastPos;
	Vector3 mouseWorld;
	bool firstClick;

	// Use this for initialization
	void Start () {
		thisCamera = Camera.main;
		lineRenderer = GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		GameObject ob = new GameObject();
		LineRenderer ln = ob.AddComponent("LineRenderer") as LineRenderer;
		lineRenderer = ln;
		lineRenderer.SetWidth(startWidth, endWidth);

		// Referencia a la variable privada para borrarla en mouseup
		lastLine = ob;

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = thisCamera.nearClipPlane;
		mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);

		lineRenderer.SetVertexCount(1);
		lineRenderer.SetPosition(0, mouseWorld);


		lastPos = mouseWorld;
		firstClick = false;

		linePoints.Clear ();
	}

	void OnMouseUp(){
		firstClick = true;
		Destroy(lastLine);
	}

	void OnMouseDrag(){
		if(!firstClick){
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = thisCamera.nearClipPlane;
			mouseWorld = thisCamera.ScreenToWorldPoint(mousePos);
			
			float dist = Vector3.Distance(lastPos, mouseWorld);
			
			if(dist <= threshold)
				return;
			
			lastPos = mouseWorld;
			
			if(linePoints == null)
				linePoints = new List<Vector3>();
			
			linePoints.Add(mouseWorld);
			
			UpdateLine();
		}


	}

	void UpdateLine(){

		lineRenderer.SetVertexCount(linePoints.Count);
		
		for(int i = lineCount; i < linePoints.Count; i++)
		{
			lineRenderer.SetPosition(i, linePoints[i]);
		}
		lineCount = linePoints.Count;
	}
}
