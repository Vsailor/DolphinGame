using UnityEngine;
using System.Collections;

public class DolphinScript : MonoBehaviour {

    public float Spead = 4f;
    public float StandartGravity = 3.5f;
    public float CurrentGravity = 4f;
    public float MinSpead;
    public Vector2 LastPosition;
    Quaternion save;

    // Use this for initialization
    void Start()
    {
        LastPosition = this.transform.position;
        save = this.transform.rotation;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (LastPosition.y > this.transform.position.y)
            {
                Spead += 1.2f;
            }
            else
            {
                if (Spead >= MinSpead)
                {
                    Spead -= 0.6f;
                }
            }
            return;
        }
        if (LastPosition.y < this.transform.position.y)
        {
            if (Spead >= MinSpead)
            {
                Spead -= 0.3f;
            }
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
        CurrentGravity += 0.07f;
    }
    // Update is called once per frame
    void Update()
    {
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

        LastPosition = this.transform.position;
    }
}
