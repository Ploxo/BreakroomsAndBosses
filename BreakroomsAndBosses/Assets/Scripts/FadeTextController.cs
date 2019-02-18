using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Denna scriptet skapar och initialiserar PopupTextParent.
public class FadeTextController : MonoBehaviour {

    private static FadeText popupText;
    private static GameObject canvas;

    //Initialize the prefab PopupTextParent in "Resources" folder
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
        //PopupText kommer att "poppa up" hos "enemy", i det scriptet den blir kallad.
        //new Vector 2(location.position.x + Random.Range(-.5f, .5f)). Kan användas för att spawna på en random offset.
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(Text);
    }


}
