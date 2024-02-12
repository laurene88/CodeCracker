using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PasswordChecker : MonoBehaviour
{
    
    [Header("The Secret Password")]
    [SerializeField] private string CorrectPassword;


    [Header ("The value from the input field")]
    [SerializeField] private string inputText;
    public TMP_InputField inputField;


    [Header("Showing the reaction to the player")]
    [SerializeField] private GameObject reactionGroup;
    [SerializeField] private TMP_Text reactionTextBox;


    public void FetchInput(string input)
    {
        inputText = input;
        checkInputCorrect();
    }

    public void checkInputCorrect(){
        if (inputText.ToLower() == CorrectPassword.ToLower()){
            DisplayReactionToCorrectInput();
        } else{
            DisplayReactionToWrongInput();
        }
    }


    public void DisplayReactionToCorrectInput(){
        Debug.Log("right password");
    }


    public void DisplayReactionToWrongInput(){
        Debug.Log("NOPE");
        ClearInputField(inputField);
    }


    public void ClearInputField(TMP_InputField inputField){
        inputField.Select();
        inputField.text = "";
    }
}
