// This script allows the player to change the state of the puzzle reflectors.
using UnityEngine;
public class PlayerReflector : MonoBehaviour
{
    public PuzzleReflector currentPuzzleReflector = null;
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (currentPuzzleReflector != null) currentPuzzleReflector.SwitchState();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleReflector")
        {
            currentPuzzleReflector = collision.GetComponent<PuzzleReflector>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PuzzleReflector")
        {
            currentPuzzleReflector = null;
        }
    }

}
