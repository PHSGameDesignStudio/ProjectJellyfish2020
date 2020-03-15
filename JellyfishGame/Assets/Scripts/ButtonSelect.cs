using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    // Start is called before the first frame update
    bool selected = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!selected)
        {
            GetComponent<Button>().Select();
            selected = true;
        }
    }
}
