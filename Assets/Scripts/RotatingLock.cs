using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingLock : MonoBehaviour
{

    // Must be added via inspector so ensure correct lock order/location
    public RotatingLockSegment[] lockSegments;

    private int[] answerCode3 = new int[] { 4, 5, 6 };


    // method called on event of lock segment changing/button press
    public void CheckLockCode()
    {
        for (int i = 0; i < lockSegments.Length; i++)
        {
            if (lockSegments[i].currentDigit != answerCode3[i])
            {
                Debug.Log("returned");               
                return;
            }
            else
            {
                Debug.Log("RIGHT CODE YAY");
            }
        }

    }

}
