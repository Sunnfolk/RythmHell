using UnityEngine;
using UnityEngine.InputSystem;

namespace Notes
{
    public class SystemInput : MonoBehaviour
    {
        // Input Bools
        [HideInInspector] public bool leftLeft;
        [HideInInspector] public bool leftMiddle;
        [HideInInspector] public bool rightMiddle;
        [HideInInspector] public bool rightRight;
        
        [HideInInspector] public bool pause;
        
        
        // Enum States
        public enum State
        {
            LeftRight,
            Thumbs,
        }
        
        public State inputSettings;
        /*  Left : Q W E R 
         *  Right: U I O P
         *  Mix  : E R U I
         *  Thumb: Q ALT < P
         */


        // Update is called once per frame
        void Update()
        {
            pause = Keyboard.current.escapeKey.wasPressedThisFrame;
            if (inputSettings == State.LeftRight)
            {
                
                LeftRight();
            }
            else if (inputSettings == State.Thumbs)
            {
                Thumbs();
            }

            
        }
        
        public void LeftRight()
        {
            // Left for Right and Left Hand (Thumb)
            leftLeft = Keyboard.current.qKey.wasPressedThisFrame || Keyboard.current.uKey.wasPressedThisFrame;
            leftMiddle = Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.iKey.wasPressedThisFrame || Keyboard.current.leftAltKey.wasPressedThisFrame;
            
            
            // Right for Right and Left Hand (Thumb)
            rightMiddle = Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.oKey.wasPressedThisFrame || Keyboard.current.rightAltKey.wasPressedThisFrame;
            rightRight = Keyboard.current.rKey.wasPressedThisFrame || Keyboard.current.pKey.wasPressedThisFrame;

            //DebugPrint();
        }

        public void Thumbs()
        {
            // Left 2
            leftLeft = Keyboard.current.qKey.wasPressedThisFrame;
            leftMiddle = Keyboard.current.leftAltKey.wasPressedThisFrame;
            
            
            // Right 2
            rightMiddle = Keyboard.current.rightAltKey.wasPressedThisFrame;
            rightRight = Keyboard.current.pKey.wasPressedThisFrame;
            
            DebugPrint();
        }

        private void DebugPrint()
        {
            print("leftLeft = " + leftLeft);
            print("leftMiddle = " + leftMiddle);
            print("rightMiddle = " + rightMiddle);
            print("rightRight = " + rightRight);
            print("Input Settings = " + inputSettings);
        }
    }
}
