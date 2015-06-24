using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
    public float spead = 0f;
    public float jumpSpead = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    Quaternion save;
	// Use this for initialization
	void Start () {
        save = this.transform.rotation;
	}
	// Update is called once per frame
	void Update () {
        var controller = GetComponent<Rigidbody2D>();
        controller.velocity = new Vector2(spead, controller.velocity.y);
        if (Mathf.Abs(this.transform.rotation.z) > 0.4)
        {
            this.transform.rotation = save;
        }
        save = this.transform.rotation;
        if (this.transform.position.x >= 10.3f)
        {
            this.transform.position = new Vector3(-181.36f, this.transform.position.y, this.transform.position.z);
        }
    }
}
