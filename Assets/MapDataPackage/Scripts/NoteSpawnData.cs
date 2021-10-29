using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnData
{
    public byte lane { get; private set; }
    public float spawnTimeSec { get; private set; }


    public NoteSpawnData(byte lane, float spawnTimeSec)
    {
        this.lane = lane;
        this.spawnTimeSec = spawnTimeSec;
    }
}
