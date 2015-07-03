using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {
    public GameObject DolphinObject;
    public float y = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(DolphinObject.transform.position.x, y);
	}
}
