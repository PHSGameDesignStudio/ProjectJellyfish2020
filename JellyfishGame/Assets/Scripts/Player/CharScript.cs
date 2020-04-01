using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public bool facingRight = true;
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        float translation = speed;
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        // Move translation along the object's z-axis
        if (Input.GetKey("w"))
        {
            transform.Translate(0, translation, 0);
            animator.SetBool("Backwards", true);
        }
        else { animator.SetBool("Backwards", false); }
        if (Input.GetKey("a"))
        {
            animator.SetBool("Walking", true);
            transform.Translate(-translation, 0, 0);
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey("d"))
        {
            animator.SetBool("Walking", true);
            transform.Translate(translation, 0, 0);
            if (facingRight)
            {
                Flip();
            }
        }
        else { animator.SetBool("Walking", false); }
        if (Input.GetKey("s"))
        {
            animator.SetBool("Forward", true);
            transform.Translate(0, -translation, 0);
        }
        else{animator.SetBool("Forward", false); }
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
