using System.Collections;
using System.Collections.Generic;
using Notes;
using UnityEngine;

public class ActivateZone : MonoBehaviour
{
    private InputSystem m_InputSystem;
    void Awake()
    {
        m_InputSystem = GetComponent<InputSystem>();
    }
    
    void Update()
    {
        if (m_InputSystem.leftLeft)
        {
            LeftLeft();
        }

        if (m_InputSystem.leftMiddle)
        {
            
        }

        if (m_InputSystem.rightMiddle)
        {
            
        }

        if (m_InputSystem.rightRight)
        {
            
        }    
    }

    private void LeftLeft()
    {
        
    }
}
