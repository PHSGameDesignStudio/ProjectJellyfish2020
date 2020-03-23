using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryScript : MonoBehaviour
{
    public Component m_Box1;
    public Component m_Box2;
    public Component m_Box3;
    public Component m_Box4;
    public Component m_Box5;
    public Component m_Box6;
    public Component m_Box7;
    public Component m_Box8;
    
    
    void Start()
    {
        GameObject.Find("Dropdown").SetActive(false);
    }
    void Attack()
    {

    }
}
