using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    string armCondition = "";
    string ballCondition = "";
    public string condition;
    [SerializeField] private GameObject self;
    [SerializeField] private GameObject startButton;

    public void Reset()
    {
        armCondition = "";
        ballCondition = "";
    }
    public void setArmCondition(int c)
    {
        if (c == 0)
        {
            armCondition = "physical";
        }
        else
        {
            armCondition = "virtual";
        }

        if (ballCondition != "")
        {
            startButton.SetActive(true);
        }
    }

    public void setBallCondition(int c)
    {
        if (c == 0)
        {
            ballCondition = "physical";
        }
        else
        {
            ballCondition = "virtual";
        }

        if (armCondition != "")
        {
            startButton.SetActive(true);
        }

    }

    public void Play()
    {
        condition = armCondition + " Arm + " + ballCondition + " Balls";
        Experiment.SetCondition(condition);
        self.SetActive(false);
    }
}
