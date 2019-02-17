using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTextController : MonoBehaviour {

    private static FadeText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("SayDialog (1)");

        //The prefab is gonna return the "tag" FadeText.
        popupText = Resources.Load<FadeText>("Prefabs/PopupTextParent");

    }

    public static void CreateFloatingText(string Text, Transform location)
    {
        //Instance är en referens till "popuptext"
        FadeText instance = Instantiate(popupText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(Text);
    }


}
