using UnityEngine;
using System.Collections;

public class A : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		p = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		
		tab.Add(p);

		Debug.Log ("click dentro de la A");
	}
}
