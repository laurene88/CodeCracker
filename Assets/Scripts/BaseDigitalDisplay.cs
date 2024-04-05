using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDigitalDisplay : DigitalDisplay
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public override void SetCorrectAnswer()
    {
        base.SetCorrectAnswer();
    }

    public override void FinishedEnteringCode()
    {
        base.FinishedEnteringCode();
    }

    public override void DisplayCodeSequence(int digitJustEntered)
    {
        base.DisplayCodeSequence(digitJustEntered);
    }

    public override void CheckResults()
    {
        base.CheckResults();    
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
        base.ResetAttempt();
    }

}
