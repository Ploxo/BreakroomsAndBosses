using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    public Animator animator;
    private Text damageText;

    void Start()
    {
        //Grab current clips from the animator and store it in the array.
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damageText = animator.GetComponent<Text>(); //GetComponent from the object that has the animator and text on.
    }

    public void SetText(string text)
    {
        damageText.text = text;
    }
}
