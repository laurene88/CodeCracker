using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DigitalDisplay : MonoBehaviour
{
    // Digital Display associated with Keypad buttons
    private string correctCode = "1234";
    
    // digit images to display
    [SerializeField] private Sprite[] digits;
    [SerializeField] private Sprite blankDisplaySprite;

    // Digit Display areas on 'keypad screen'
    [SerializeField] private Image[] characters;
    private string codeSequence;


    public void CheckButtonPress(){
            CheckResults();
        }


    //could call on awake to instantiate correct numbers of 
    // display character boxes.

    
    // Start is called before the first frame update
    void Start()
    {
        codeSequence = "";

        for (int i = 0; i <= characters.Length-1; i++)
        {
            characters[i].sprite = blankDisplaySprite; //all show the blank one originally
        }
        //subscribe this script to buttonPressed event.
        PushKeypadButton.ButtonPressed += AddDigitToCodeSequence;
    }


    private void AddDigitToCodeSequence(string digitEntered){
        if (codeSequence.Length < correctCode.Length){
            switch (digitEntered){
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
                  //  codeSequence += "*";
                    //DisplayCodeSequence();  NOTE tutorial vid includes these separately
                   // break;
                //case "#":
                  //  CheckResults();
            }
        
        }
    }

    private void DisplayCodeSequence(int digitJustEntered){
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

    private void CheckResults(){
        if (codeSequence == correctCode)
        {
            Debug.Log(codeSequence+ " : "+correctCode);
            Debug.Log("you win");
            ResetDisplay();
        } else {
            Debug.Log("you lose");
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < characters.Length; i++){
            characters[i].sprite = blankDisplaySprite;
        }
        codeSequence = "";
    }

    // remove listener if not needed.
    private void OnDestroy(){
        PushKeypadButton.ButtonPressed -= AddDigitToCodeSequence;
    }
}
