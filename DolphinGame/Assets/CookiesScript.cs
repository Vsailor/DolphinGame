using UnityEngine;
using System.Collections;

public class CookiesScript : MonoBehaviour
{
    public GameObject MainCamera;
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
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.Find("Dolphin").GetComponent<DolphinScript>().IsActive)
        {
            AnimatorComponent.Play(TriggerAnimation);
            var component = MainCamera.GetComponent<CameraScript>();
            component.ScoreAmount += 5;
            component.CoinSoundPlay();
        }
    }
}
