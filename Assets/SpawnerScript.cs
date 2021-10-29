using System;
using System.Collections;
using System.Collections.Generic;
using Notes;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private MapData mapData;
    [SerializeField] private ActivateZone activateZone;
    [SerializeField] private GameObject[] notePrefabs;
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private float noteSpeed;
    [SerializeField] private GameObject hitPoint;

    private float spawnBeforeSec;
    
    private MapReader mapReader;
    private AudioSource audioSource;
    

    private void Awake()
    {
        mapReader = new MapReader(mapData);
        audioSource = GetComponent<AudioSource>();

        spawnBeforeSec = (spawners[0].transform.position.y - hitPoint.transform.position.y) / noteSpeed;
    }

    private void Start()
    {
        StartCoroutine(PlayMap());
    }

    private void OnValidate()
    {
        GetComponent<AudioSource>().clip = mapData.song;
    }

    private IEnumerator PlayMap()
    {
        audioSource.Play();
        for (int i = 0; i < mapReader.Count; ++i)
        {
            NoteSpawnData noteSpawnData = mapReader.NextNoteSpawnData();
            while (noteSpawnData.spawnTimeSec - spawnBeforeSec >= audioSource.time)
            {
                yield return null;
            }
            //Do spawn stuff here
            GameObject note = SpawnNote(noteSpawnData);
            note.GetComponent<noteMovement>().NoteSpeed = noteSpeed;
            activateZone.notes.Add(note);
        }
    }

    private GameObject SpawnNote(NoteSpawnData noteSpawnData)
    {
        return Instantiate(notePrefabs[noteSpawnData.lane], spawners[noteSpawnData.lane].transform.position, transform.rotation);
    }

}
