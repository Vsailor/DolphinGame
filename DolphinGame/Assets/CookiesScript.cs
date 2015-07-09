using UnityEngine;
using System.Collections;

public class CookiesScript : MonoBehaviour
{
   
    public string TriggerAnimation;
    public static int[] CookiesAmount =
        {
        19,
        22,
        23,
        16,
        19,
        22,
        16,
        23,
        18,
        18,
        18,
        23
    };
    private Animator AnimatorComponent;
    // Use this for initialization
    void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
        TriggerAnimation = "GemsAnimation";
        AnimatorComponent.Play("StartGems");
        GameObject.Find("Dolphin").GetComponent<DolphinScript>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        AnimatorComponent.Play(TriggerAnimation);
    }
    //void OnTriggerExit2D(Collider2D collision)
    //{
    //}
    // Update is called once per frame
    void Update()
    {

    }
}
