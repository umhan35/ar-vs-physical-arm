using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class Experiment
{
    private static string condition = "";
    private static int participantID;
    private static int trialNumber = 0;
    public static string s;
    //private static IReadOnlyList<Windows.Storage.StorageFile> file;

    public static void SetCondition(string c)
    {
        condition = c;
    }

    public static void IncreaseTrialNumber()
    {
        trialNumber++;
    }

    public static void SetUp()
    {
        participantID = PlayerPrefs.GetInt("ID", 0);
        PlayerPrefs.SetInt("ID", (participantID+1));
        condition = "";
        trialNumber = 0;
        s = "empty";
    }

    public static void Reset()
    {
        trialNumber = 0;
        s = "empty";
    }

    //public static void EndExperiment()
    //{
    //    GameObject container = GameObject.Find("PanelContainer");
    //}

    private static string getTimeStamp()
    {
        System.DateTime moment = System.DateTime.Now;
        string timeStamp = moment.Day.ToString() + "/" + moment.Month.ToString() + "/" + moment.Year.ToString() + " " + moment.Hour.ToString() + ":" + moment.Minute.ToString() + ":" + moment.Second.ToString() + ":" + moment.Millisecond.ToString();
        return timeStamp;
    }
    public static void ObjLookedAt(GameObject gameObject)
    {
        s = participantID + "," + trialNumber + "," + condition + "," + "Looked At" + "," + gameObject.name + "," + getTimeStamp();
    }

    public static void ObjLookedAway(GameObject gameObject)
    {
        s = participantID + "," + trialNumber + "," + condition + "," + "Looked Away" + "," + gameObject.name + "," + getTimeStamp();
    }

    public static void RobotStartMove(string ball)
    {
        s = participantID + "," + trialNumber + "," + condition + "," + "Robot Starts Moving" + "," + ball + "," + getTimeStamp();
    }

    public static void RobotStopMove()
    {
        s = participantID + "," + trialNumber + "," + condition + "," + "Looked Away" + "," + " " + "," + getTimeStamp();
    }

    public static void ObjClicked(string name)
    {
        s = participantID + "," + trialNumber + "," + condition + "," + "User Clicked" + "," + name + "," + getTimeStamp();
    }
}