using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TextField : MonoBehaviour
{
    [SerializeField] InputField inputField;
    public string letter;

    private void Update()
    {
        inputField.ActivateInputField();
    }

    public void GetInput(string letter_)
    {
        letter = letter_;
    }

    
}