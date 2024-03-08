using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PushKeypadButton : MonoBehaviour
{
// https://www.youtube.com/watch?v=mL-FLsV3WRs&list=PLPLsh0LxcxbdA54kChAdBKXfvZcFOdZw8&index=26&ab_channel=AlexanderZotov
    public static event Action<string> ButtonPressed = delegate {};

    private string buttonName, buttonValue;
    // Start is called before the first frame update
    void Start()
    {
        buttonName = gameObject.name;
                                    //(start, length)
        buttonValue = buttonName.Substring(0,1);
        // when this is pressed, button click method invoked, 
        // which in turns fired button pressed event 
        // which passes button value to a game object
        // ready to react to this event.
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked(){
        ButtonPressed(buttonValue);
       // Debug.Log(this.buttonValue);
    }

}
