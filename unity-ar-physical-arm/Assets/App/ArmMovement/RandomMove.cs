using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RosSharp.RosBridgeClient
{
    public class RandomMove : MonoBehaviour
    {
        public bool RUN = false;

        public int pointingTo;

        public int userPoint;

        [SerializeField] private GameObject endPanel;

        [SerializeField] private GameObject resetButton;

        [SerializeField] private int trialLen = 10;

        private int conditionCount;

        [SerializeField] private ControlPublisher script;

        private string[] orders = { "left", "center left", "center", "center right", "right" };

        private string home = "home";

        // Start is called before the first frame update
        void Start()
        {
            Experiment.SetUp();
            conditionCount = 0;
            pointingTo = 9;
            userPoint = 9;
            script.order = home;
        }
        
        // Update is called once per frame

        public void setRunTrue()
        {
            RUN = true;
        }

        public void userPointTo(int sphere)
        {
            userPoint = sphere;
            Experiment.ObjClicked("sphere" + sphere);
        }

        void Update()
        {
            if (RUN == true)
            {
                RUN = false;
                StartCoroutine(Trial());
            }
        }

        IEnumerator Trial()
        {
            Experiment.Reset();
            int index;
            for (int i = 0; i < trialLen; i++)
            {
                Experiment.IncreaseTrialNumber();
                index = Random.Range(0, orders.Length);
                pointingTo = index;
                script.order = orders[index];
                script.UpdateMessage();
                Experiment.RobotStartMove("sphere" + index);
                yield return new WaitUntil(() => userPoint != 9);

                userPoint = 9;

                script.order = home;
                script.UpdateMessage();
                yield return new WaitForSeconds(5);

            }
            if (conditionCount == 3)
            {
                endPanel.SetActive(true);
            }
            else
            {
                resetButton.SetActive(true);
            }
            conditionCount++;
            yield return null;
        }
    }
}