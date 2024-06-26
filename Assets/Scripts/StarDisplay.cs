using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class StarDisplay : MonoBehaviour
{
    // Digital Display associated with Keypad buttons
    private readonly string correctCode = "1234";
    [SerializeField] private TMP_Text textreference;
    private string codeSequence;
    public Image lightImage;
    public Color lightImageColor;


    void Start()
    {
        codeSequence = "";
        textreference.text = "";
        lightImageColor = lightImage.color;
        //subscribe this script to buttonPressed event.
        PushKeypadButton.ButtonPressed += AddDigitToCodeSequence;
    }

 

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if (codeSequence.Length < correctCode.Length)
        {
            switch (digitEntered)
            {
                case "0":
                    codeSequence += "0";
                    textreference.text = textreference.text + "*";
                    break;
                case "1":
                    codeSequence += "1";
                    textreference.text = textreference.text + "*";
                    break;
                case "2":
                    codeSequence += "2";
                    textreference.text = textreference.text + "*";
                    break;
                case "3":
                    codeSequence += "3";
                    textreference.text = textreference.text + "*";
                    break;
                case "4":
                    codeSequence += "4";
                    textreference.text = textreference.text + "*";
                    break;
                case "5":
                    codeSequence += "5";
                    textreference.text = textreference.text + "*";
                    break;
                case "6":
                    codeSequence += "6";
                    textreference.text = textreference.text + "*";
                    break;
                case "7":
                    codeSequence += "7";
                    textreference.text = textreference.text + "*";
                    break;
                case "8":
                    codeSequence += "8";
                    textreference.text = textreference.text + "*";
                    break;
                case "9":
                    codeSequence += "9";
                    textreference.text = textreference.text + "*";
                    break;
                default:
                    Debug.Log("default case");
                    break;
                    //  case "*":
                    //  playerEnteredCodeSequence += "*";
                    //DisplayCodeSequence();  NOTE tutorial vid includes these separately
                    // break;
                    //case "#":
                    //  CheckResults();
            }
            if (codeSequence.Length == correctCode.Length)
            {
                Invoke(nameof(CheckResults), 0.5f);
            }
        }
    }

    IEnumerator ShortPause()
    {
        yield return new WaitForSeconds(2f);
    }

    public void CheckResults()
    {
      //  StartCoroutine(ShortPause());
        if (codeSequence == correctCode)
        {
            DisplayReactionToCorrectInput();
        }
        else
        {
            DisplayReactionToIncorrectInput();
        }
        // StartCoroutine(ShortPause());
        Invoke(nameof(ResetAttempt), 1f) ;
    }

    //IEnumerator CheckResults()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    if (codeSequence == correctCode)
    //    {
    //        DisplayReactionToCorrectInput();
    //    }
    //    else
    //    {
    //        DisplayReactionToIncorrectInput();
    //    }
    //    yield return new WaitForSeconds(1f);
    //    ResetAttempt();
    //}


    public void  DisplayReactionToIncorrectInput()
    {
        lightImage.GetComponent<Image>().color = Color.red;
        Debug.Log("you lose");
    }

    public void DisplayReactionToCorrectInput()
    {
        lightImage.GetComponent<Image>().color = Color.green;
        Debug.Log(codeSequence + " : " + correctCode);
        Debug.Log("you win");
    }

    // Resets current code sequence and all digit displays to blank.
    private void ResetAttempt()
    {
        textreference.text = "";
        codeSequence = "";
        lightImage.GetComponent<Image>().color = lightImageColor;
    }

    // remove listener if not needed.
    private void OnDestroy()
    {
        PushKeypadButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}

