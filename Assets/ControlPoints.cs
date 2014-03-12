using UnityEngine;
using System.Collections;

public class ControlPoints : MonoBehaviour {

	private int clickCounter;
	public int index;
	public bool startPoint;
	public bool endPoint;

	private Path letra;

	// Use this for initialization
	void Start () {
		letra = transform.parent.GetComponent<Path>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDrag(){
		if (letra.counter == (index-1)){
			letra.counter = index;
		}

	}

	void OnMouseOver(){
		Debug.Log("!!!!");
		if (letra.counter == (index-1)){
			letra.counter = index;
		}
	}

	void OnMouseDown(){
		clickCounter++;
		if (clickCounter == 1){



		}
	}
}
