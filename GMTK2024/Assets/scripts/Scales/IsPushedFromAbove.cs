using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPushedFromAbove : MonoBehaviour
{
    public bool isPushedFromAbove = false;
    public string targetTag = "Weight";
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            isPushedFromAbove = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            isPushedFromAbove = false;
        }
    }
}
