using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextMover : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    TMP_Text soulCountUI;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoulCounter>().ATextUpdate += TextUpdate;    
        soulCountUI = gameObject.GetComponent<TMP_Text>();
    }

    private void TextUpdate(string count)
    {
        soulCountUI.text = count;   
        AnimateText();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

    void AnimateText()
    {
        animator.SetTrigger("Update");
    }
}
