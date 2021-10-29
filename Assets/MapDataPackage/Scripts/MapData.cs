using System;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    [Header("Song Data")]
    [SerializeField] public AudioClip song;
    [Tooltip("BPM of song (Constant)")]
    [SerializeField] public float bpm = 1f;
    [Tooltip("Seconds waited after audio clip start, until the first note hits (does not consider the Hell Modifier)")]
    [SerializeField] public float waitSecondsBeforeFirstNote;
    [Tooltip("Amount of lanes to place notes in")] 
    [SerializeField] public byte laneAmount = 1;

    [Header("MapData")]
    [SerializeField] private MapInstruction[] mapData;

    [HideInInspector] public SortedDictionary<uint, byte[]> noteBeatPosition16ths = new SortedDictionary<uint, byte[]>();

    private void OnValidate()
    {
        //Inspector check
        bpm = Mathf.Max(1, bpm);
        waitSecondsBeforeFirstNote = Mathf.Max(0, waitSecondsBeforeFirstNote);
        laneAmount = (byte)Mathf.Max(1f, laneAmount);
        
        //Generate noteBeatPosition (+ Inspector validation)
        noteBeatPosition16ths.Clear();
        uint currentBeat = 0;
        foreach (MapInstruction mi in mapData)
        {
            //inspector validation
            for (int i = 0; i < mi.spawnInLane.Length; ++i)
            {
                if (mi.spawnInLane[i] >= laneAmount)
                {
                    //mi.spawnInLane[i] = (byte)(laneAmount - 1); //Terminated cause it would delete placed notes by changing laneAmount back and fourth
                    Debug.LogError("Element in mapData.spawnInLane is bigger than the amount of lanes");
                }

                if (Array.FindAll(mi.spawnInLane, s => s == mi.spawnInLane[i]).Length > 1)
                {
                    Debug.LogError("Element in MapData.spawnInLane is put on top of another element (noteception)");
                }
            }
            mi.fractionCount = (uint)Mathf.Max(1, mi.fractionCount);
            if (mi.waitFraction == 0)
            {
                mi.waitFraction = MapInstruction.WaitFraction.Quarter;
            }
            
            //add to noteBeatPosition
            noteBeatPosition16ths.Add(currentBeat, mi.spawnInLane);
            currentBeat += mi.fractionCount * (16 / (uint)mi.waitFraction);
        }
    }
}
