using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRepeater : MonoBehaviour {
    public int m_maxRailSegments = 1000;
    public float offset = -1.455f;
	// Use this for initialization
	void Start () {
        
        Vector3 previousTrackSegmentPosition = gameObject.transform.position;
        Debug.Log("Spawner Location: " + previousTrackSegmentPosition);

        for (int segmentIndex = 0; segmentIndex < m_maxRailSegments; ++segmentIndex)
        {
            GameObject trackSegment = Instantiate(Resources.Load<GameObject>("prefab\\GARAILROAD")) as GameObject;
            trackSegment.transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
            trackSegment.transform.position = previousTrackSegmentPosition + new Vector3(0.0f, 0.0f, offset) * segmentIndex;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
