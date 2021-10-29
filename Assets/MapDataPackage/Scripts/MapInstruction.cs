using System;
using UnityEngine;

[Serializable]
public class MapInstruction
{
    public enum WaitFraction
    {
        Whole = 1, Half = 2, Quarter = 4, Eighth = 8, Sixteenth = 16
    }
    
    [Tooltip("how many notes spawned, in which lane index. Range: (0 - {LaneAmount - 1})")]
    [SerializeField] public byte[] spawnInLane;
    [Tooltip("How many fractals are counted before wait is over")]
    [SerializeField] public uint fractionCount;
    [Tooltip("The fraction (noteLength) that is counted for the musical pause")] 
    [SerializeField] public WaitFraction waitFraction;
}
