/* 
 * Copyright (c) 2018 Razeware LLC 
 *  
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to deal 
 * in the Software without restriction, including without limitation the rights 
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 * copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions: 
 *  
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software. 
 * 
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish,  
 * distribute, sublicense, create a derivative work, and/or sell copies of the  
 * Software in any work that is designed, intended, or marketed for pedagogical or  
 * instructional purposes related to programming, coding, application development,  
 * or information technology.  Permission for such use, copying, modification, 
 * merger, publication, distribution, sublicensing, creation of derivative works,  
 * or sale is expressly withheld. 
 *     
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE. 
 */

using Vuforia;
using UnityEngine;
using System.Diagnostics;

public class PizzaTrackableEventHandler : MonoBehaviour
{
    #region PROTECTED_MEMBER_VARIABLES 

    protected ObserverBehaviour mTrackableBehaviour;
    #endregion // PROTECTED_MEMBER_VARIABLES 

    #region UNITY_MONOBEHAVIOUR_METHODS 

    /* 
    protected virtual void Start() 
    { 
        mTrackableBehaviour = GetComponent<ObserverBehaviour>(); 
        if (mTrackableBehaviour) 
        { 
            mTrackableBehaviour.RegisterTrackableEventHandler(this); 
        } 
    }*/
    /* 
 
    protected virtual void OnDestroy() 
    { 
        if (mTrackableBehaviour) 
        { 
            mTrackableBehaviour.UnregisterTrackableEventHandler(this); 
        } 
    }*/

    #endregion // UNITY_MONOBEHAVIOUR_METHODS 

    #region PUBLIC_METHODS 

    /// <summary> 
    ///     Implementation of the ITrackableEventHandler function called when the 
    ///     tracking state changes. 
    /// </summary> 
    public void OnTrackableStateChanged(Status previousStatus, Status newStatus)
    {
        if (newStatus == Status.TRACKED || newStatus == Status.EXTENDED_TRACKED)
        {
          //  Debug.Log("Trackable " + mTrackableBehaviour.TargetName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == Status.TRACKED &&
                 newStatus == Status.NO_POSE)
        {
         ///   Debug.Log("Trackable " + mTrackableBehaviour.TargetName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND 
            // Vuforia is starting, but tracking has not been lost or found yet 
            // Call OnTrackingLost() to hide the augmentations 
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS 

    #region PROTECTED_METHODS 

    protected virtual void OnTrackingFound()
    {

    }


    protected virtual void OnTrackingLost()
    {

    }

    #endregion // PROTECTED_METHODS 
}