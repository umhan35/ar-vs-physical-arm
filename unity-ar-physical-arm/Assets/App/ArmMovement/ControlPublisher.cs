using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class ControlPublisher : UnityPublisher<MessageTypes.Std.String>
    {
        public string FrameId = "Unity";

        private MessageTypes.Std.String message;
        private MessageTypes.Std.String clearMessage;

        public string order;

        public bool runOrder = true;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void FixedUpdate()
        {
            if (runOrder == true)
            {
                UpdateMessage();
                runOrder = false;
            }
        }

        private void InitializeMessage()
        {
            message = new MessageTypes.Std.String();
            clearMessage = new MessageTypes.Std.String("empty");
        }

        public void UpdateMessage()
        {
            message = new MessageTypes.Std.String(order);

            Publish(message);
            Publish(clearMessage);
        }


    }
}

// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// using UnityEngine;
// using Unity.Robotics.ROSTCPConnector;
// using RosMessageTypes.UnityRoboticsDemo;

// public class RosPublisherExample : MonoBehaviour
// {
//     ROSConnection ros;
//     public string topicName = "chatter";

//     // The game object
//     // public GameObject cube;
//     // Publish the cube's position and rotation every N seconds
//     public float publishMessageFrequency = 0.5f;

//     // Used to determine how much time has elapsed since the last message was published
//     private float timeElapsed;

//     void Start()
//     {
//         // start the ROS connection
//         ros = ROSConnection.GetOrCreateInstance();
//         // ros.RegisterPublisher<PosRotMsg>(topicName);
//     }

//     private void Update()
//     {
//         timeElapsed += Time.deltaTime;

//         if (timeElapsed > publishMessageFrequency)
//         {
//             // cube.transform.rotation = Random.rotation;

//             // PosRotMsg cubePos = new PosRotMsg(
//             //     cube.transform.position.x,
//             //     cube.transform.position.y,
//             //     cube.transform.position.z,
//             //     cube.transform.rotation.x,
//             //     cube.transform.rotation.y,
//             //     cube.transform.rotation.z,
//             //     cube.transform.rotation.w
//             // );


//             // Finally send the message to server_endpoint.py running in ROS
//             ros.Publish(topicName, cubePos);

//             timeElapsed = 0;
//         }
//     }
// }
