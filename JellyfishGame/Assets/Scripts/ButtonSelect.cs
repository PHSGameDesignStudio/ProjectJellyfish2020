using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour
{
    // Start is called before the first frame update
    bool selected = false;
    void Start()
    {
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
