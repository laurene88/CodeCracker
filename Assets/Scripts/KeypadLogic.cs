using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadLogic : MonoBehaviour
{
    //-----------------------------------------------------------------------------------------------------------------------------
    // Controls the correct code, entered code, logic and display for a keypad.
    // Requires a Keypad/button press script and subscribes to its button pressed events
    // Requires some set up in scene eg - associating pictures for display, and areas for display.
    // This is setup for digit display areas which are UI Images, with the sprites changing as needed.
    // (Will need variation/new variables for if want to have a TMP reference as the display.)
    //------------------------------------------------------------------------------------------------------------------------------

    //TODO display correct result outcome shows a popup panel/prefab?


    // String codes for lock
    public string correctCode;
    public string playerEnteredCodeSequence;

    // Variables to display each digit input as a sprite on an image.
    // Digit Sprites to display, blank, and for each possible digit.
    [SerializeField] public Sprite[] digitSprites;
    [SerializeField] public Sprite blankDisplaySprite;
 
    // Digit Display areas on 'keypad screen'
    // Should be equal to number of characters in code
    [SerializeField] public Image[] digitDisplayPositions;

    // Check results as soon as entered, or only after pressing a 'check' button.
    public bool AutoCheckResults = false;

    // Start is called before the first frame update
    void Start()
    {
        StartLock();
    }

    public virtual void StartLock()
    {
        SetCorrectAnswer();
        PushKeypadButton.ButtonPressed += AddDigitToCodeSequence;
    }

    public virtual void SetCorrectAnswer()
    {
        correctCode = "1234";
    }

    // This method subscribes to the Button Press methods from a Keypad Button Script.
    public virtual void AddDigitToCodeSequence(string digitEntered)
    {
        if (playerEnteredCodeSequence.Length < correctCode.Length)
        {
            switch (digitEntered)
            {
                case "0":
                    playerEnteredCodeSequence += "0";
                    DisplayCodeSequence(0);
                    break;
                case "1":
                    playerEnteredCodeSequence += "1";
                    DisplayCodeSequence(1);
                    break;
                case "2":
                    playerEnteredCodeSequence += "2";
                    DisplayCodeSequence(2);
                    break;
                case "3":
                    playerEnteredCodeSequence += "3";
                    DisplayCodeSequence(3);
                    break;
                case "4":
                    playerEnteredCodeSequence += "4";
                    DisplayCodeSequence(4);
                    break;
                case "5":
                    playerEnteredCodeSequence += "5";
                    DisplayCodeSequence(5);
                    break;
                case "6":
                    playerEnteredCodeSequence += "6";
                    DisplayCodeSequence(6);
                    break;
                case "7":
                    playerEnteredCodeSequence += "7";
                    DisplayCodeSequence(7);
                    break;
                case "8":
                    playerEnteredCodeSequence += "8";
                    DisplayCodeSequence(8);
                    break;
                case "9":
                    playerEnteredCodeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
                default:
                    //Debug.Log("default case");
                    break;
                    //  case "*":
                    //  playerEnteredCodeSequence += "*";
                    //DisplayCodeSequence();  NOTE tutorial vid includes these separately
                    // break;
                    //case "#":
                    //  CheckResults();
            }
        }
        if (playerEnteredCodeSequence.Length == correctCode.Length)
            {
                FinishedEnteringCode();
            }
    }

    // Updates the display to reflect the playerEnteredCodeSequence. IMAGES SLIDE FROM RIGHT TO LEFT.
    // DisplayPositions are Images as will be UI based.
    // image.sprite and image.color are easily changed.
    public virtual void DisplayCodeSequence(int digitJustEntered)
    {
        switch (playerEnteredCodeSequence.Length)
        {
            case 1:
                digitDisplayPositions[0].sprite = blankDisplaySprite;
                digitDisplayPositions[1].sprite = blankDisplaySprite;
                digitDisplayPositions[2].sprite = blankDisplaySprite;
                digitDisplayPositions[3].sprite = digitSprites[digitJustEntered];
                break;
            case 2:
                digitDisplayPositions[0].sprite = blankDisplaySprite;
                digitDisplayPositions[1].sprite = blankDisplaySprite;
                digitDisplayPositions[2].sprite = digitDisplayPositions[3].sprite;
                digitDisplayPositions[3].sprite = digitSprites[digitJustEntered];
                break;
            case 3:
                digitDisplayPositions[0].sprite = blankDisplaySprite;
                digitDisplayPositions[1].sprite = digitDisplayPositions[2].sprite;
                digitDisplayPositions[2].sprite = digitDisplayPositions[3].sprite;
                digitDisplayPositions[3].sprite = digitSprites[digitJustEntered];
                break;
            case 4:
                digitDisplayPositions[0].sprite = digitDisplayPositions[1].sprite;
                digitDisplayPositions[1].sprite = digitDisplayPositions[2].sprite;
                digitDisplayPositions[2].sprite = digitDisplayPositions[3].sprite;
                digitDisplayPositions[3].sprite = digitSprites[digitJustEntered];
                break;
        }
    }

    // Allows option to check results as soon as code is finished being entered
    // Depends on boolean AutoCheckResults
    // Waits half a second to allow for visual updates.
    public virtual void FinishedEnteringCode()
    {
        if (AutoCheckResults)
        {
            Invoke(nameof(CheckResults), 0.5f);
        }
        else
        {
            return;
        }
    }

    // Checks results, may be asap by FinishedEnteringCode, or by specific button press calling this method.
    public virtual void CheckResults()
    {
        //Unity should call Equals with operator overload for strings so should work fine?
        // https://stackoverflow.com/questions/3678792/are-string-equals-and-operator-really-same
        if (playerEnteredCodeSequence == correctCode)
        {
            DisplayReactionToCorrectInput();
        }
        else
        {
            DisplayReactionToIncorrectInput();
        }
    }


    public virtual void DisplayReactionToIncorrectInput()
    {
        Debug.Log("you lose");
        Invoke(nameof (ResetAttempt), 1f); // 1 second wait before reset
    }


    public virtual void DisplayReactionToCorrectInput()
    {
        Debug.Log(playerEnteredCodeSequence + " : " + correctCode);
        Debug.Log("you win");
        Invoke(nameof(ResetAttempt), 1f); // 1 second wait before reset
    }


    // MUST reset display images to blank, and playerEnteredCodeSequence to "".
    // Will never need to do separately as are entwined.
    public virtual void ResetAttempt()
    {
        for (int i = 0; i < digitDisplayPositions.Length; i++)
        {
            digitDisplayPositions[i].sprite = blankDisplaySprite;
        }
        playerEnteredCodeSequence = "";
    }


    // Remove listener if no longer needed. Non overridable.
    public void OnDestroy()
    {
        PushKeypadButton.ButtonPressed -= AddDigitToCodeSequence;
    }


}

