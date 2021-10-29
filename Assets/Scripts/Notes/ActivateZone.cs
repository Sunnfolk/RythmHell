using System;
using System.Collections.Generic;
using Effects;
using TMPro;
using UnityEngine;

namespace Notes
{
    public class ActivateZone : MonoBehaviour
    {
        // Lists
        [Header("Lists")]
        public List<GameObject> notes;

        
        // Ranges for different scores
        [Header("Score Range")]
        [SerializeField] private float perfectRange ;
        [SerializeField] private float goodRange;
        [SerializeField] private float badRange = 1f;

        [Header("Combo")]
        public int comboCounter;
        private int m_ComboMultiplier = 1;

        //Score
        // Score per hit
        [Header("Score")]
        public float scoreCounter;
        [SerializeField] private float perfectScore = 100f;
        [SerializeField] private float goodScore = 50f;
        [SerializeField] private float badScore = 25f;
        
        [Header("Text")]
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text comboText;
        [SerializeField] private TMP_Text comboMultiplierText;
        
        
        //Location of the TriggerZones
        [Header("Positions")]
        [SerializeField] private GameObject leftLeftPosition;
        [SerializeField] private GameObject leftMiddlePosition;
        [SerializeField] private GameObject rightMiddlePosition;
        [SerializeField] private GameObject rightRightPosition;

        [SerializeField] private GameObject missPosition;
    
        // Components
        private SystemInput m_InputSystem;
        
        
        private SoundEffects m_Sound;
        
        private void Awake()
        {
            m_InputSystem = GetComponent<SystemInput>();
            
            
            m_Sound = GetComponent<SoundEffects>();
        }
        
        private void Update()
        {
            // Todo: LightEffects for button presses
            if (m_InputSystem.leftLeft)
            {
                CheckTiming(leftLeftPosition.transform.position);
            }

            if (m_InputSystem.leftMiddle)
            {
                CheckTiming(leftMiddlePosition.transform.position);
            }

            if (m_InputSystem.rightMiddle)
            {
                CheckTiming(rightMiddlePosition.transform.position);
            }

            if (m_InputSystem.rightRight)
            {
                CheckTiming(rightRightPosition.transform.position);
            }
            Miss();
            TextUpdates();
        }
        // Checks the timings of the button presses, and sends the results on down the line.
        private void CheckTiming(Vector3 position)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (Math.Abs(position.x - notes[i].transform.position.x) < 0.2)
                {
                    if (Math.Abs(notes[i].transform.position.y - position.y) < perfectRange)
                    {
                        // TODO: Particle here
                        // TODO: Sound Effects Here ??DONE??

                        Destroy(notes[i]);
                        notes.RemoveAt(i);


                        ScoreRangeInput("Perfect");
                        //print("Perfect!!!!!");
                    }
                    else if (Math.Abs(notes[i].transform.position.y - position.y) < goodRange)
                    {
                        Destroy(notes[i]);
                        notes.RemoveAt(i);
                        ScoreRangeInput("Good");
                        //print("good!!!!!");
                    }
                    else if (Math.Abs(notes[i].transform.position.y - position.y) < badRange)
                    {
                        Destroy(notes[i]);
                        notes.RemoveAt(i);
                        ScoreRangeInput("Bad");
                        //print("bad wut tf u doing!!!!!");
                    }
                }
            }
        }
        
        // If you don't hit the notes
        private void Miss()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].transform.position.y <= missPosition.transform.position.y)
                {
                    Destroy(notes[i]);
                    notes.RemoveAt(i);
                    Combo("Miss");
                }
            }
        }
        
        // SCORE INPUTS //
        private void ScoreRangeInput(string scoreRange)
        {
            m_Sound.HitSound();
            
            if (scoreRange == "Perfect")
            {
                // TODO: Spawn The Word Sprites plus Particles When they're Hit
                Combo("Perfect");
            }
            if (scoreRange == "Good")
            {
                Combo("Good");
            }
            if (scoreRange == "Bad")
            {
                Combo("Bad");
            }
            if (scoreRange == "Miss")
            {
                Combo("Miss");
            }
        }
        
        
        // COMBO FROM SCORE INPUTS // 
        private void Combo(string comboRange)
        {
            if (comboRange == "Perfect")
            {
                comboCounter = ++comboCounter;
                Score("Perfect");
            }

            if (comboRange == "Good")
            {
                comboCounter = ++comboCounter;
                Score("Good");
            }

            if (comboRange is "Bad" or "Miss")
            {
                comboCounter = 0;
                
                // Todo: LightEffects for Miss
                Score(comboRange == "Miss" ? "Miss" : "Bad");
            }

            //comboText.text = comboCounter.ToString();
            
            if (comboCounter >= 50)
            {
                m_ComboMultiplier = 8;
            }
            else if (comboCounter >= 25)
            {
                m_ComboMultiplier = 4;
            }
            else if (comboCounter >= 10)
            {
                m_ComboMultiplier = 2;
            }
            else
            {
                m_ComboMultiplier = 1;
            }
            //comboMultiplierText.text = comboMultiplier.ToString();
        }
        
        
        // SCORE FROM COMBO //
        private void Score(string scoreRange)
        {
            if (scoreRange == "Perfect")
            {
                scoreCounter = (perfectScore * m_ComboMultiplier) + scoreCounter;
            }
            if (scoreRange == "Good")
            {
                scoreCounter = (goodScore * m_ComboMultiplier) + scoreCounter;
            }
            if (scoreRange == "Bad")
            {
                scoreCounter = (badScore * m_ComboMultiplier) + scoreCounter;
            }

            if (scoreRange == "Miss")
            {
                
            }
            //scoreText.text = scoreCounter + " P";
        }
        //Updates Text
        private void TextUpdates()
        {
            comboText.text = comboCounter.ToString();
            comboMultiplierText.text = m_ComboMultiplier.ToString();
            scoreText.text = scoreCounter + " P";
        }
    }
}
