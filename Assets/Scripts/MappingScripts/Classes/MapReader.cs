using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MapReader
{
    private MapData mapData;
    
    public int Count { get; private set; }
    
    private readonly NoteSpawnData[] noteTimingPlacement;
    private uint currentIndex;

    public MapReader(MapData mapData)
    {
        this.mapData = mapData;
        List<NoteSpawnData> noteSpawnDataList = new List<NoteSpawnData>(mapData.noteBeatPosition16ths.Count);
        uint i = 0;
        foreach (uint k in mapData.noteBeatPosition16ths.Keys)
        {
            foreach (byte il in mapData.noteBeatPosition16ths[k])
            {
                noteSpawnDataList.Add(new NoteSpawnData(il, k / 4f * 60f / mapData.bpm));
            }
        }
        this.noteTimingPlacement = noteSpawnDataList.ToArray();
        this.Count = noteTimingPlacement.Length;
    }

    public void Reset()
    {
        currentIndex = 0;
    }

    public NoteSpawnData NextNoteSpawnData()
    {
        return noteTimingPlacement[currentIndex++];
    }
}
