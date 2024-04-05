using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CombinationLockSegment : MonoBehaviour
{
    // For one digit slot of a lock.
    // Set on the Panel, with image/2xbuttons linked.

    // digit sprites to display, set in inspector.
    [SerializeField] private Sprite[] digitsSprites = new Sprite[10];

    public Image digitImage;
    public int currentDigit;

     public Button upButton;
     public Button downButton;

    public UnityEvent recheckLock;

    private void Awake()
    {
        currentDigit = 0;
      //  digitImage = GetComponentInChildren<Image>();
       // Debug.Log(digitImage.name);
        UpdateDigit();

    }

    public void UpButtonPressed()
    {
        currentDigit = (currentDigit + 1) % 10;
        UpdateDigit();
        recheckLock.Invoke();
    }

    public void DownButtonPressed()
    {
        if (currentDigit == 0) {
            currentDigit = 9;
            } else {
            currentDigit--;
            }
        UpdateDigit();        
        recheckLock.Invoke();
    }

    private void UpdateDigit()
    {
        this.digitImage.sprite = digitsSprites[currentDigit];
    }

}

    // (if all digitSprites & images correct - auto open.) - this can be done by a separate panel code.
