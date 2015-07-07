using UnityEngine;
using System.Collections;

public class CookiesScript : MonoBehaviour
{
    public string TriggerAnimation;
    private Animator AnimatorComponent;
    public const int COOKIES1_AMOUNT = 19;
    public const int COOKIES2_AMOUNT = 22;
    public const int COOKIES3_AMOUNT = 23;
    public const int COOKIES4_AMOUNT = 16;
    // Use this for initialization
    void Start()
    {
        AnimatorComponent = GetComponent<Animator>();
        TriggerAnimation = "GemsAnimation";
        AnimatorComponent.Play("StartGems");
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
