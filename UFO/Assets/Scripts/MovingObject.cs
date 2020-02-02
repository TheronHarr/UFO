using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingObject : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 10.0F;
    private float startTime;
    private float journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(startMarker.position, endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;

        
        float fractionOfJourney = distCovered / journeyLength;


        transform.position = Vector2.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fractionOfJourney, 1));
    }
}
