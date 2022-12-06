using System.Collections.Generic;

namespace RosSharp.RosBridgeClient
{
    public class CSVPublisher : UnityPublisher<MessageTypes.Std.String>
    {
        public string FrameId = "Unity";

        private MessageTypes.Std.String message;

        protected override void Start()
        {
            base.Start();
            message = new MessageTypes.Std.String();
        }

        public void Update()
        {
            if (Experiment.s != "empty")
            {
                UpdateMessage(Experiment.s);
                Experiment.s = "empty";
            }
        }

        public void UpdateMessage(string line)
        {
            message = new MessageTypes.Std.String(line);

            Publish(message);
        }


    }
}
