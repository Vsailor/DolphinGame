using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {
    public GameObject DolphinObject;
	void Update () {
        this.transform.position = new Vector3(DolphinObject.transform.position.x, this.transform.position.y);
	}
}
