using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
    public float Spead = 0f;
    public float StandartGravity = 4f;
    public float CurrentGravity = 4f;

    Quaternion save;

    // Use this for initialization
    void Start()
    {
        save = this.transform.rotation;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Spead += 0.1f;
        }
    }

    void CheckRotation()
    {
        var controller = GetComponent<Rigidbody2D>();
        controller.velocity = new Vector2(Spead, controller.velocity.y);
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
    void MoveDown()
    {
        CurrentGravity += 0.1f;
    }
	// Update is called once per frame
	void Update () {
        CheckRotation();
        if (Input.GetKey(KeyCode.Space))
        {
            MoveDown();
        }
        else
        {
            CurrentGravity = StandartGravity;
        }
        GetComponent<Rigidbody2D>().gravityScale = CurrentGravity;
    }
}
