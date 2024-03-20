using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoginChecker : MonoBehaviour
{
    private string answerUsername = "username";
    private string answerPassword = "password";

    public TMP_InputField usernameField;
    public TMP_InputField passwordField;

    private string InputUsername;
    private string InputPassword;


    public void OnLoginButtonPress()
    {
        FetchInput();
        CheckInputCorrect();
    }


    public void FetchInput()
    {
        InputUsername = usernameField.text;
        InputPassword = passwordField.text;
    }

    //This is CaSe SeNsItIvE
    public void CheckInputCorrect()
    {
        if (InputUsername.Equals(answerUsername) && InputPassword.Equals(answerPassword))
        {
            DisplayReactionToCorrectInput();
        }
        else
        {
            DisplayReactionToWrongInput();
        }
    }


    public void DisplayReactionToCorrectInput()
    {
        Debug.Log("right passwords");
        ClearInputFields();
    }


    public void DisplayReactionToWrongInput()
    {
        Debug.Log("NOPE");
        Debug.Log(InputUsername + "ANS "+answerUsername);
        Debug.Log(InputPassword + "ANS " + answerPassword); 
        ClearInputFields();
    }

    public void ClearInputFields()
    {
        usernameField.text = "";
        passwordField.text = "";
    }

}
