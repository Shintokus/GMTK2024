using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBackToZero : MonoBehaviour
{

    public float maxReturnSpeed = 5.0f; // Maximum speed at which the object returns to zero rotation
   
    public IsPushedFromAbove cupRight;
    public IsPushedFromAbove cupLeft;

    void Start()
    {
      
    }

    void Update()
    {
        if (!cupRight.isPushedFromAbove && !cupLeft.isPushedFromAbove)
        {            // Calculate the difference in rotation
            float angleDifference = Mathf.Abs(transform.rotation.eulerAngles.z);

            // Calculate the return speed based on the angle difference
            float returnSpeed = Mathf.Lerp(0, maxReturnSpeed, angleDifference / 180.0f);

            // Smoothly interpolate the rotation back to zero
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * returnSpeed);
        }
    }

   

    
}
