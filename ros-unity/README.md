# ROS-Unity

## Dependencies

- Ubuntu 20.04
- python2: `sudo apt install python`
- ROS Noetic
  - [Install & Set up environment](http://wiki.ros.org/noetic/Installation/Ubuntu)
  - Set up catkin workspace
```
mkdir -p ~/catkin_ws/src
cd ~/catkin_ws/
sudo apt-get install python3-catkin-tools python3-osrf-pycommon
catkin build
```
  - Clone this repo to `src` folder
```
cd src
git clone git@gitlab.com:mirrorlab/ar-vs-real-arm/ros-unity.git
catkin build
```
  - Install ROS package dependencies
```
sudo apt install ros-noetic-moveit ros-noetic-rosbridge-suite
```
  - Arm related ROS packages
```
sudo apt install ros-noetic-arbotix-controllers ros-noetic-arbotix-python
# in the `src` folder
git clone https://github.com/AnasIbrahim/widowx_arm
# ingore the widowx_block_manipulation package since it is not working on Ubuntu 20.04
cd widowx_arm/widowx_block_manipulation/
touch CATKIN_IGNORE
cd -
catkin build
```
  - `rosed widowx_arm_bringup arm.launch` and comment out `<node name="robot_state_pub" pkg="robot_state_publisher" type="robot_state_publisher"/>`
    - comment out like `<!--<node name="robot_state_pub" pkg="robot_state_publisher" type="robot_state_publisher"/> -->`
  - Add permission to access usb devices (arm): `sudo adduser $USER dialout`. Roboot.

## How to run

### All at once

Physical robot: `roslaunch waypoints bringup.launch`

---

We also have a launch file to launch everything in sim __on the same computer__. The ROS master port is 11312 and ros socket port is **9091**, which should be set properly in Unity. (By default, these two ports are 11311 and 9090.)

Robot sim: `roslaunch waypoints bringupsim.launch -p 11312`

#### Individually


In order to establish a connection to Unity run the following command on the computer running ROS and connected to the robot arm:

    roslaunch rosbridge_server rosbridge_websocket.launch

A game object can be placed into the Unity scene from the prefab.
Make sure that the correct IP is shown on the Unity game object (the port should be 9090). You can check the ROS computers IP with ```hostname -I```

You can then run the physical arm (remove the sim part if you want it in simulation):

    roslaunch widowx_arm_bringup arm_moveit.launch sim:=false

Run the waypoints node:

    roslaunch waypoints waypoints.launch

(Test: `rostopic pub /chatter std_msgs/String "data: 'home'" -1`. This should put the robot arm in its home position.)

Run the CSV log node:

    rosrun csv csv_node

Note: use `ctrl - \` to quite the two nodes above
