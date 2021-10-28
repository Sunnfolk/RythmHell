using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Notes
{
    public class ActivateZone : MonoBehaviour
    {
        // Components
        private SystemInput m_InputSystem;

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
        private int comboMultiplier = 1;

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
        [SerializeField] private Transform leftLeftPosition;
        [SerializeField] private Transform leftMiddlePosition;
        [SerializeField] private Transform rightMiddlePosition;
        [SerializeField] private Transform rightRightPosition;
    
        void Awake()
        {
            m_InputSystem = GetComponent<SystemInput>();
        }
    
        void Update()
        {
            if (m_InputSystem.leftLeft)
            {
                CheckTiming(leftLeftPosition.position);
            }

            if (m_InputSystem.leftMiddle)
            {
                CheckTiming(leftMiddlePosition.position);
            }

            if (m_InputSystem.rightMiddle)
            {
                CheckTiming(rightMiddlePosition.position);
            }

            if (m_InputSystem.rightRight)
            {
                CheckTiming(rightRightPosition.position);
            }
        }
        private void CheckTiming(Vector3 position)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                if (Math.Abs(position.x - notes[i].transform.position.x) < 0.2)
                {
                    if (Math.Abs(notes[i].transform.position.y - position.y) < perfectRange)
                    {
                        // TODO: Particle here in LeftLeft//
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
                        //print("gooooot!!!!!");
                    }
                    else if (Math.Abs(notes[i].transform.position.y - position.y) < badRange)
                    {
                        Destroy(notes[i]);
                        notes.RemoveAt(i);
                        ScoreRangeInput("Bad");
                        //print("bad wut tf u doin!!!!!");
                    }
                }
            }
        }
        
        // SCORE INPUTS //
        private void ScoreRangeInput(string scoreRange)
        {
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
                
                if (comboRange == "Miss")
                {
                    Score("Miss");
                }
                else
                {
                    Score("Bad");
                }
            }

            comboText.text = comboCounter.ToString();
            
            if (comboCounter >= 50)
            {
                comboMultiplier = 8;
            }
            else if (comboCounter >= 25)
            {
                comboMultiplier = 4;
            }
            else if (comboCounter >= 10)
            {
                comboMultiplier = 2;
            }
            else
            {
                comboMultiplier = 1;
            }
            comboMultiplierText.text = comboMultiplier.ToString();
        }
        
        
        // SCORE FROM COMBO //
        public void Score(string scoreRange)
        {
            if (scoreRange == "Perfect")
            {
                scoreCounter = (perfectScore * comboMultiplier) + scoreCounter;
            }
            if (scoreRange == "Good")
            {
                scoreCounter = (goodScore * comboMultiplier) + scoreCounter;
            }
            if (scoreRange == "Bad")
            {
                scoreCounter = (badScore * comboMultiplier) + scoreCounter;
            }

            if (scoreRange == "Miss")
            {
                
            }

            scoreText.text = scoreCounter + " P";
        }
        
    }
}
