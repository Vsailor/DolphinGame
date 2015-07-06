using UnityEngine;
using System.Collections;

public class CookiesScript : MonoBehaviour {
    private Animator AnimatorComponent;
	// Use this for initialization
	void Start () {
        AnimatorComponent = GetComponent<Animator>();
        //AnimatorComponent.Play("Finish");
        AnimatorComponent.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        AnimatorComponent.enabled = true;
        AnimatorComponent.Play("GemsAnimation");
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        //AnimatorComponent.Play("Start");
    }
	// Update is called once per frame
	void Update () {
	}
}
