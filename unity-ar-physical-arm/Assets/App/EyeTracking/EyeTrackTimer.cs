using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackTimer : MonoBehaviour
{
    public float timer = 0;
    public bool timing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timing == true)
        {
            timer += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        //start moving the arm thingy
        timer = 0;
        timing = true;


    }

    public void StopTimer()
    {
        timing = false;
    }
}
