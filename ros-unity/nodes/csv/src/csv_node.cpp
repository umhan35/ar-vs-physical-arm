#include <cmath>
#include "ros/ros.h"
#include "std_msgs/String.h"
#include <fstream>
#include <unistd.h>
#include <pwd.h>

std::string DATA;

class Writer
{
private:
    ros::NodeHandle node_handle;
    std::string filename;
    std::ofstream myFile;
public:

    ros::NodeHandle getNodeHandle()
    {
        return node_handle;
    }
        
    void initialize()
    {
        filename = std::string(getpwuid(getuid())->pw_dir) + "/ar-arm-experiment-log.csv";
        ROS_DEBUG_STREAM("Log file: " << filename);
        // myFile.open(filename, std::ios_base::app);
        // myFile << "ParticipantID, TrialNumber, Condition, EventName, EventObject, TimeStamp" << std::endl;
        // myFile.close();
    }

    void write()
    {
        if (DATA != "empty")
        {
            myFile.open(filename, std::ios_base::app);
            myFile << DATA << std::endl;
            myFile.close();
            DATA = "empty";

        }
    }

    void main_loop()
    {
        write();
    }

};

void listen(const std_msgs::String::ConstPtr& msg)
{
    std::string data = msg->data.c_str();
    ROS_INFO("I heard: [%s]", msg->data.c_str());
    DATA = data;
}

int main(int argc, char **argv)
{
    ros::init(argc, argv, "csv_node");
    Writer this_node;

    ros::Subscriber subscriber = this_node.getNodeHandle().subscribe("csv", 1000, listen);

    ros::AsyncSpinner spinner(1);
    spinner.start();
    this_node.initialize();


    while(true)
    {
        this_node.main_loop();
    }
    return 0;
}
