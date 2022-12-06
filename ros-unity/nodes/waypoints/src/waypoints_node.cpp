#include <moveit/move_group_interface/move_group_interface.h>
#include <moveit/planning_scene_interface/planning_scene_interface.h>
#include <cmath>

#include "ros/ros.h"
#include "std_msgs/String.h"


std::string COMMAND;

class Waypoints
{
private:
    ros::NodeHandle node_handle;
    const double tau = 2 * M_PI;
    std::string PLANNING_GROUP = "widowx_arm";
    moveit::planning_interface::MoveGroupInterface *move_group_interface;
    moveit::planning_interface::PlanningSceneInterface planning_scene_interface;
    const moveit::core::JointModelGroup *joint_model_group;
    moveit::planning_interface::MoveGroupInterface::Plan my_plan;
    std::vector<double> joint_group_positions;
    moveit::core::RobotStatePtr current_state;
        
    
public:

    ros::NodeHandle getNodeHandle()
    {
        return node_handle;
    }
        
    void initialize()
    {
        move_group_interface = new moveit::planning_interface::MoveGroupInterface(PLANNING_GROUP);
        current_state = move_group_interface->getCurrentState();
        joint_model_group = move_group_interface->getCurrentState()->getJointModelGroup(PLANNING_GROUP);
        current_state->copyJointGroupPositions(joint_model_group, joint_group_positions);
        move_group_interface->setMaxVelocityScalingFactor(1);
        move_group_interface->setMaxAccelerationScalingFactor(1);
    }

    void orders()
    {
        if (COMMAND == "home")
        {
            moveHome();
        }
        else if (COMMAND == "left")
        {
            pointLeft();
        }
        else if (COMMAND == "center left")
        {
            pointCenterLeft();
        }
        else if (COMMAND == "center")
        {
            pointCenter();
        }
        else if (COMMAND == "center right")
        {
            pointCenterRight();
        }
        else if (COMMAND == "right")
        {
            pointRight();
        }
    }
    void moveHome()
    {
        joint_group_positions[0] = 0;
        joint_group_positions[1] = -tau/4;
        joint_group_positions[2] = tau/4;
        joint_group_positions[3] = -tau/4;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void pointLeft()
    {
        joint_group_positions[0] = -tau/4;
        joint_group_positions[1] = tau/5;
        joint_group_positions[2] = -tau/12;
        joint_group_positions[3] = 0;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void pointCenterLeft()
    {
        joint_group_positions[0] = -tau/8;
        joint_group_positions[1] = tau/5;
        joint_group_positions[2] = -tau/9;
        joint_group_positions[3] = 0;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void pointCenter()
    {
        joint_group_positions[0] = 0;
        joint_group_positions[1] = tau/5;
        joint_group_positions[2] = -tau/9;
        joint_group_positions[3] = 0;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void pointCenterRight()
    {
        joint_group_positions[0] = tau/8;
        joint_group_positions[1] = tau/5;
        joint_group_positions[2] = -tau/9;
        joint_group_positions[3] = 0;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void pointRight()
    {
        joint_group_positions[0] = tau/4;
        joint_group_positions[1] = tau/5;
        joint_group_positions[2] = -tau/12;
        joint_group_positions[3] = 0;
        joint_group_positions[4] = 0;
        move_group_interface->setJointValueTarget(joint_group_positions);
        move_group_interface->plan(my_plan);
        move_group_interface->execute(my_plan);
    }

    void main_loop()
    {
        orders();
    }

};

void callback(const std_msgs::String::ConstPtr& msg)
{
    std::string moveCommand = msg->data.c_str();
    ROS_INFO("I heard: [%s]", msg->data.c_str());
    COMMAND = moveCommand;
}

int main(int argc, char **argv)
{
    ros::init(argc, argv, "waypoints_node");
    Waypoints this_node;

    ros::Subscriber subscriber = this_node.getNodeHandle().subscribe("chatter", 1000, callback);

    ros::AsyncSpinner spinner(1);
    spinner.start();
    this_node.initialize();


    while(true)
    {
        this_node.main_loop();
    }
    return 0;
}