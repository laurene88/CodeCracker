using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
public class CombinationLock : MonoBehaviour
{
    //TODO 
    // change so group three lock segments together, answer is in terms of two-three set locks.?
    // somehow do it so matches on screen.. without doing manually?

    // Must be added via inspector, ENSURE correct lock order/lock location on screen.
    public CombinationLockSegment[] lockSegments;

    public Sprite closedLock;
    public Sprite openLock;
    public Image lockImage;

    [SerializeField]
    public int[] answerCode;

    private void Awake()
    {
        lockImage = GetComponent<Image>();
        lockImage.sprite = closedLock;
        }
  

    // method called on event of lock segment changing/button press
    public void CheckLockCode()
    {
        for (int i = 0; i < lockSegments.Length; i++)
        {
            if (lockSegments[i].currentDigit != answerCode[i])
            {
                DisplayReactionToIncorrectInput();
                return;
            }
        }
        DisplayReactionToCorrectInput(); // if reaches this code, numerical code is correct
    }

   public void DisplayReactionToIncorrectInput()
    {
    }

    public void DisplayReactionToCorrectInput()
    {            
        lockImage.sprite = openLock; 
    }
   
    }

//Debugging locks: Debug.Log(lockSegments[0].currentDigit + ":" + answerCode3[0] + "  " + lockSegments[1].currentDigit + ":" + answerCode3[1] + "    " + lockSegments[2].currentDigit + ":" + answerCode3[2]);