using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public GameObject bear;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 9; i++) {
			Instantiate(bear);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
