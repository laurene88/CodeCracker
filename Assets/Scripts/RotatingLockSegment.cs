using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatingLockSegment : MonoBehaviour
{
    // For one digit slot of a lock.
    // Set on the Panel, with image/2xbuttons linked.

    // digit sprites to display, set in inspector.
    [SerializeField] private Sprite[] digitsSprites = new Sprite[10];

    public Image digitImage;
    public int currentDigit;

     public Button upButton;
     public Button downButton;

    private void Awake()
    {
        currentDigit = 0;
      //  digitImage = GetComponentInChildren<Image>();
        Debug.Log(digitImage.name);
        UpdateDigit();
    }

    public void UpButtonPressed()
    {
        currentDigit = (currentDigit + 1) % 10;
        UpdateDigit();
    }

    public void DownButtonPressed()
    {
        if (currentDigit == 0) {
            currentDigit = 9;
            } else {
            currentDigit--;
            }
        UpdateDigit();
    }

    private void UpdateDigit()
    {
        this.digitImage.sprite = digitsSprites[currentDigit];
    }

}

    // (if all digits & images correct - auto open.) - this can be done by a separate panel code.
