using UnityEngine;
using System.Collections;

public class DolphinScript : MonoBehaviour
{
    private KeyCode Touch = KeyCode.Mouse0;
    public float Spead = 4f;
    public float StandartGravity = 3.5f;
    public float CurrentGravity = 4f;
    public float MinSpead;
    public Vector2 LastPosition;
    Quaternion LastRotation;
    bool Inited = false;

    // Use this for initialization
    void Start()
    {
        LastPosition = this.transform.position;
        LastRotation = this.transform.rotation;
        Rand = new System.Random();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (Spead < MinSpead)
        {
            Spead = MinSpead;
        }

        if (Input.GetKey(Touch))
        {
            if (LastPosition.y > this.transform.position.y)
            {
                Spead += 1.4f;
                if (LastPosition.y < this.transform.position.y)
                {
                    if (Spead > 20)
                    {
                        Spead -= 5f;
                        return;
                    }
                }
            }
            else
            {
                if (Spead - 0.4f >= MinSpead)
                {
                    Spead -= 0.4f;
                }
            }
            return;
        }
        if (LastPosition.y < this.transform.position.y)
        {
            if (Spead > 20)
            {
                Spead -= 5f;
                return;
            }
            
            if (Spead - 0.4f >= MinSpead)
            {
                Spead -= 0.4f;
            }
            return;
        }


    }

    void CheckRotation()
    {

        var controller = GetComponent<Rigidbody2D>();
        controller.velocity = new Vector2(Spead, controller.velocity.y);
        if (!Input.GetKey(Touch))
        {
            if (this.transform.position.y < LastPosition.y)
            {

                this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + 0.02f, this.transform.rotation.w);
            }
        }

        if (Mathf.Abs(this.transform.rotation.z) > 0.3)
        {
            this.transform.rotation = LastRotation;
        }

        LastRotation = this.transform.rotation;

    }
    static System.Random Rand;
    static void GenerateCookie(string name, int amount)
    {
        GameObject obj;
        Animator comp;
        var random = Rand.Next(0, 3);

        for (int i = 0; i < amount; i++)
        {
            obj = GameObject.Find(name + " " + i);
            comp = obj.GetComponent<Animator>();
            if (random == 0)
            {
                comp.Play("StartGems");
                obj.GetComponent<CookiesScript>().TriggerAnimation = "GemsAnimation";
            }
            else if (random == 1)
            {
                comp.Play("StartStars");
                obj.GetComponent<CookiesScript>().TriggerAnimation = "StarsAnimation";
            }
            else
            {
                comp.Play("StartCoins");
                obj.GetComponent<CookiesScript>().TriggerAnimation = "CoinsAnimation";
            }
        }


    }
    public static void GenerateCookies()
    {
        for (int i = 0; i < CookiesScript.CookiesAmount.Length; i++)
        {
            GenerateCookie("Cookies" + (i + 1), CookiesScript.CookiesAmount[i]);
        }

    }
    void Teleport()
    {//-334.31
        if (this.transform.position.x >= 231.5f)
        {
            this.transform.position = new Vector3(-344.5f, this.transform.position.y, this.transform.position.z);
            GenerateCookies();
        }
    }

    void MoveDown()
    {
        if (CurrentGravity <= 10f)
        {
            CurrentGravity += 0.07f;
        }
        this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + 0.02f, this.transform.rotation.w);

    }
    void Init()
    {
        GenerateCookies();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Inited)
        {
            Inited = true;
            Init();
        }
        Teleport();
        CheckRotation();
        if (Input.GetKey(Touch))
        {
            MoveDown();
        }
        else
        {
            if (LastPosition.y < this.transform.position.y && Mathf.Abs(this.transform.rotation.z - 0.08f) <= 0.3)
            {
                this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 0.08f, this.transform.rotation.w);
            }

            //this.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 0.1f, this.transform.rotation.w);
            CurrentGravity = StandartGravity;
        }
        GetComponent<Rigidbody2D>().gravityScale = CurrentGravity;

        LastPosition = this.transform.position;

    }
}
