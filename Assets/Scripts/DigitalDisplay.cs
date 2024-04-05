using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DigitalDisplay : MonoBehaviour
{
    // Parent class that updates a display relative to buttons pressed.
    // Subscribes to PushKeypadButton.ButtonPressed.

    // Digital Display associated with Keypad buttons
    public string correctCode;
    
    // digit images to display
    //NO! THESE ARENT ALWAYS SPRITES.
    [SerializeField] public Sprite[] digits;
    [SerializeField] public Sprite blankDisplaySprite;

    // Digit Display areas on 'keypad screen'
    [SerializeField] public Image[] characters;

    public string codeSequence = "";


    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        //Can probably get rid of this, just set correctly in scene.
        for (int i = 0; i <= characters.Length-1; i++)
        {
            characters[i].sprite = blankDisplaySprite; //all show the blank one originally
        }
        //subscribe this script to buttonPressed event.
       
    }

    public virtual void StartGame()
    {        
        SetCorrectAnswer();
        PushKeypadButton.ButtonPressed += AddDigitToCodeSequence;
    }
    public virtual void SetCorrectAnswer()
    {
        correctCode = "1234";
    }


    public void AddDigitToCodeSequence(string digitEntered){
        if (codeSequence.Length < correctCode.Length)
        {
            switch (digitEntered)
            {
                case "0":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "1":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "2":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "3":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "4":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "5":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "6":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "7":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "8":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "9":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
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
        }
            if (codeSequence.Length == correctCode.Length)
            {
               FinishedEnteringCode();
            }
    }

    // Changes the Display code sprites, depending on the digit of the code entered, either 1,2,3 or 4.
    public virtual void DisplayCodeSequence(int digitJustEntered){
        switch (codeSequence.Length)
        {
            case 1:
                characters[0].sprite = blankDisplaySprite;
                characters[1].sprite = blankDisplaySprite;
                characters[2].sprite = blankDisplaySprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 2:
                characters[0].sprite = blankDisplaySprite;
                characters[1].sprite = blankDisplaySprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 3:
                characters[0].sprite = blankDisplaySprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
            case 4:
                characters[0].sprite = characters[1].sprite;
                characters[1].sprite = characters[2].sprite;
                characters[2].sprite = characters[3].sprite;
                characters[3].sprite = digits[digitJustEntered];
                break;
        }
    }

    // Allows option to check results as soon as code is finished being entered.
    public virtual void FinishedEnteringCode() 
    { 
        Invoke(nameof(CheckResults), 2f); // call when finished entering, but with a pause.
    }

    // Checks results, may be as soon as code is finished being entered, or by specific button press.
    public virtual void CheckResults(){
        if (codeSequence == correctCode)
        {
            DisplayReactionToCorrectInput();
        } else {
            DisplayReactionToIncorrectInput();
        }
    }

    public virtual void DisplayReactionToIncorrectInput()
    {
        Debug.Log("you lose");
        Invoke(nameof(ResetAttempt), 1f);
    }

    public virtual void DisplayReactionToCorrectInput()
    {            
        Debug.Log(codeSequence+ " : "+correctCode);
        Debug.Log("you win");
        Invoke(nameof(ResetAttempt), 1f);
    }

    // Resets current code sequence and all digit displays to blank.
    // Will never need to do separately as are entwined.
    public virtual void ResetAttempt()
    {
        for (int i = 0; i < characters.Length; i++){
            characters[i].sprite = blankDisplaySprite;
        }
        codeSequence = "";
    }

    // remove listener if no longer needed.
    private void OnDestroy(){
        PushKeypadButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}
