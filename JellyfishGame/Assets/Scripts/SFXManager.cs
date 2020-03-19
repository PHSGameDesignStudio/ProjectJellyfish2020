using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static Transform thisTransform;
    public void Start()
    {
        thisTransform = transform;
    }
    public void Update()
    {
        thisTransform = transform;
    }
    // Used if you want to make a new sfx from scratch from a sound file in Resources folder
    public static GameObject SFX(string sfx, bool path = true)
    {
        if (path) sfx = "sfx/" + sfx; // If path is true the sfx path should be in Resources/sfx else its just Resources.
        GameObject rObj = Instantiate(new GameObject()) as GameObject; // Creates object.
        rObj.AddComponent<AudioSource>().clip = Resources.Load<AudioClip>(sfx); // Sets clip.
        rObj.transform.SetParent(thisTransform);
        Reset(rObj);
        return rObj;
    }
    // Used if you want to reset the audio source on the gameObject
    public static void Reset(GameObject soundObj)
    {
        soundObj.GetComponent<AudioSource>().enabled = false;
        soundObj.GetComponent<AudioSource>().enabled = true;
    }
    // Used if you want to reset an object attached to the SFXManager parent.
    public static void ResetSFX(string soundName)
    {
        var soundObj = thisTransform.Find(soundName);
        soundObj.GetComponent<AudioSource>().enabled = false;
        soundObj.GetComponent<AudioSource>().enabled = true;
    }
}
