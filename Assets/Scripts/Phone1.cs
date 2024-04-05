using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Phone1: DigitalDisplay
{

   [SerializeField]
    public Image[] DisplayPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public override void SetCorrectAnswer()
    {
        base.SetCorrectAnswer();
    }

    public override void FinishedEnteringCode()
    {
        CheckResults(); //As soon as all values are entered, check if the code is correct.
    }

    //public override void CheckResults()
    //{
    //    base.CheckResults();
    //}

    public override void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
                DisplayPoints[0].color = Color.gray;
                break;
            case 2:
                DisplayPoints[1].color = Color.gray;
                break;
            case 3:
                DisplayPoints[2].color = Color.gray;
                break;
            case 4:
                DisplayPoints[3].color = Color.gray;
                break;
        }
 
}

    public override void DisplayReactionToCorrectInput()
    {
        base.DisplayReactionToCorrectInput();
    }

    public override void DisplayReactionToIncorrectInput()
    {
        base.DisplayReactionToIncorrectInput();
    }

    public override void ResetAttempt()
    {
        codeSequence = "";
        DisplayPoints[0].color = Color.white;
        DisplayPoints[1].color = Color.white;
        DisplayPoints[2].color = Color.white;
        DisplayPoints[3].color = Color.white;
    }



}
