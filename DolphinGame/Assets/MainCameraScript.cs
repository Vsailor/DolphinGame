using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {
    public GameObject Background;
    void OnGUI()
    {
        var resolution = string.Empty;
        try
        {
            resolution = (Screen.width * 1.0 / Screen.height * 1.0).ToString().Substring(0, 4);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            resolution = (Screen.width * 1.0 / Screen.height * 1.0).ToString();
        }
        if (resolution == "1.70")
        {
            Background.transform.localScale = new Vector3(1.44f, 1.27f, 1f);
        }
        else if (resolution == "1.78")
        {
            Background.transform.localScale = new Vector3(1.51f, 1.27f, 1f);
        }
        else if (resolution == "1.66")
        {
            Background.transform.localScale = new Vector3(1.41f, 1.27f, 1f);
        }
        else if (resolution == "1.50")
        {
            Background.transform.localScale = new Vector3(1.27f, 1.27f, 1f);
        }
        else if (resolution == "1.60")
        {
            Background.transform.localScale = new Vector3(1.35f, 1.27f, 1f);
        }
    }

}
