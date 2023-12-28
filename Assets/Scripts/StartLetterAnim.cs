using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartLetterAnim : MonoBehaviour
{
    public TextMeshProUGUI[] letterTexts;
    Animator[] anims;
    char[] letters = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆおらりるれろわをん".ToCharArray();

    void Start()
    {
        
        //choose random letters
        foreach(TextMeshProUGUI letterText in letterTexts)
        {
            letterText.text = letters[UnityEngine.Random.Range(0, 46)].ToString();
        }

        //choose random animation start frame
        anims = GetComponentsInChildren<Animator>();

        foreach (Animator ani in anims)
        {
            ani.Play("letter jiggle", -1, Random.Range(0f, 1f));
        }
    }

}
