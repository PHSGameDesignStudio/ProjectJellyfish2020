using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public int Event;
    public Text_Manager textManager;
    public Collider2D Itself;
    public CharScript Player;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        Debug.Log("hello");
        textManager.Dialouge = Event;
        Debug.Log(Event);
        textManager.enabled = false;
        textManager.enabled = true;
        Player.animator.SetBool("Backward", false);
        Player.animator.SetBool("Forward",false);
        Player.animator.SetBool("Walking",false);
        Player.Flip();
        Destroy(Itself);
    }
}
