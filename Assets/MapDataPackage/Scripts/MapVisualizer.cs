using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(AudioSource))]
public class MapVisualizer : MonoBehaviour
{
    [Header("Map Data")]
    [SerializeField] public MapData mapData;

    [Header("Current Beat")]
    [Tooltip("Drag in inspector to scroll where in the song is played")]
    [SerializeField] public float currentBeat;

    [Header("Play Song")] 
    [SerializeField] private bool playMapOnPlay = true;

    [Header("Visualization")]
    [SerializeField] public float quarterBeatDistance;

    [SerializeField] public bool disableHitLine;
    [SerializeField] public bool disableQuarterBeats;
    [SerializeField] public bool disableLanes;
    [SerializeField] public bool disableNotes;

    [Header("MainCamera")] 
    [SerializeField] public Camera mainCamera;

    private AudioSource audioSource;

    private void OnValidate()
    {
        currentBeat = Mathf.Max(0, currentBeat);
        quarterBeatDistance = Mathf.Max(0.01f, quarterBeatDistance);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mapData.song;
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        if (!playMapOnPlay)
            return;
        audioSource.time = currentBeat * 60 / mapData.bpm;
        audioSource.Play();
    }

    private void Update()
    {
        if (!playMapOnPlay)
            return;
        currentBeat = audioSource.time * mapData.bpm / 60f;
    }
}

/*[CustomEditor(typeof(MapVisualizer))]
public class MapVisualizerEditor : Editor
{
    public void OnSceneGUI()
    {
        MapVisualizer mapVisualizer = target as MapVisualizer;

        Vector3 cameraPos = mapVisualizer.mainCamera.transform.position;
        Vector2 cameraHalfSize = new Vector2(mapVisualizer.mainCamera.orthographicSize * mapVisualizer.mainCamera.aspect,
            mapVisualizer.mainCamera.orthographicSize);
        Vector2 cameraSize = cameraHalfSize * 2f;
        Vector2 cameraEdgeMin = (Vector2)cameraPos - cameraHalfSize;
        Vector2 cameraEdgeMax = (Vector2) cameraPos + cameraHalfSize;
        
        float laneWidth = cameraSize.x / mapVisualizer.mapData.laneAmount;

        //Draw quarter beats
        if (!mapVisualizer.disableQuarterBeats)
        {
            for (int i = 0; i < cameraSize.y / mapVisualizer.quarterBeatDistance; ++i)
            {
                float yPos = cameraEdgeMin.y + mapVisualizer.currentBeat % 1 * -mapVisualizer.quarterBeatDistance +
                             i * mapVisualizer.quarterBeatDistance + mapVisualizer.quarterBeatDistance;
                float thickness = 1f;
                if (((int)mapVisualizer.currentBeat + i + 1) % 4 == 0)
                {
                    Handles.color = new Color(0f, 1f, 1f, 0.8f);
                    thickness = 2f;
                }
                else
                {
                    Handles.color = new Color(0f, 1f, 1f, 0.3f);
                }
                Handles.DrawLine(new Vector3(cameraEdgeMin.x, yPos), new Vector3(cameraEdgeMax.x, yPos), thickness);
            }
        }

        //Draw HitLine
        if (!mapVisualizer.disableHitLine)
        {
            Handles.color = Color.red;
            Handles.DrawLine(new Vector3(cameraEdgeMin.x, cameraEdgeMin.y), new Vector3(cameraEdgeMax.x, cameraEdgeMin.y), 2f);
        }

        //Draw Lanes
        if (!mapVisualizer.disableLanes)
        {
            Handles.color = new Color(0, 0, 1f, 0.5f);
            for (int i = 0; i < mapVisualizer.mapData.laneAmount + 1; ++i)
            {
                float xPos = cameraEdgeMin.x + i * laneWidth;
                Handles.DrawLine(new Vector3(xPos, cameraEdgeMin.y), new Vector3(xPos, cameraEdgeMax.y), 2f);
            }
        }
        
        //Draw Notes
        if (!mapVisualizer.disableNotes)
        {
            Handles.color = Color.green;
            uint start16th = (uint)(mapVisualizer.currentBeat * 4);
            for (uint i = 0; i < cameraSize.y / mapVisualizer.quarterBeatDistance * 4; ++i)
            {
                uint current16th = start16th + i;
                if (!mapVisualizer.mapData.noteBeatPosition16ths.TryGetValue(current16th, out byte[] inLanes))
                    continue;
                float yPos = cameraEdgeMin.y + i * mapVisualizer.quarterBeatDistance / 4 - mapVisualizer.currentBeat % 0.25f * mapVisualizer.quarterBeatDistance;
                foreach (byte il in inLanes)
                {
                    Handles.DrawLine(new Vector3(cameraEdgeMin.x + il * laneWidth, yPos),
                        new Vector3(cameraEdgeMin.x + il * laneWidth + laneWidth, yPos), 4);
                }
            }
        }
    }*/
//}
