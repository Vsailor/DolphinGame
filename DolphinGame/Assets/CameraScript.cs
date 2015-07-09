using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public GameObject Dolphin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        this.transform.position = new Vector3(Dolphin.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
        if (Dolphin.transform.position.y > this.transform.position.y)
        {
            Camera.main.orthographicSize += Dolphin.transform.position.y - this.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        else if (Dolphin.transform.position.y < this.transform.position.y && Camera.main.orthographicSize >8.56)
        {
            Camera.main.orthographicSize -= this.transform.position.y - Dolphin.transform.position.y;
            this.transform.position = new Vector3(this.transform.position.x, Dolphin.transform.position.y, this.transform.position.z);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
