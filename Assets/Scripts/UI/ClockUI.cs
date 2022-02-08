using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockUI : MonoBehaviour
{
    private Transform clockHandTransform;
    private Transform minHandTransform;
    private float day;
    private float hoursPerDay = 24f;
    private const float REAL_SECONDS_PER_INGAME_DAY = 600f;
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;
        float dayNormalized = day % 1f;
        float rotationDegreesPerDay = 360f;
        clockHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay - 258.5f);
        minHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay + 8).ToString("00");
        string minString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * 60f).ToString("00");

        timeText.text = hoursString + ":" + minString;

    }
    private void Awake()
    {
        timeText = transform.Find("timeText").GetComponent<Text>();
        clockHandTransform = transform.Find("clockHand");
        minHandTransform = transform.Find("minHand");
        
    }
}
