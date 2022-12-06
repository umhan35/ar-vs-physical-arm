# AR arm vs. physical arm

Code for the experiment.

## Dependencies:
 - Unity 2019.4.19f1 (this version is archived, to install it, copy paste `unityhub://2019.4.19f1/ca5b14067cec` to your browser's address bar)
   - Select these 3 modules: "Microsoft Visual Studio Community 2019", "Universal Windows Platform Build Support", and "Documentation"
 - ROS code: See ros-unity-main.zip

## Building:

There are two builds:

1. App-P for physical arm
2. App-V for virtual arm

By default it buils App-P, which uses the physical arm ROS port 9090.

To build App-V that uses port 9091:

1. Search and select `WidowXMovement` in Scene hierachy
2. Go to inspecter, find `Ros Bridge Server Url` and change port from `9090` to `9091`
3. Open `File` -> `Build Settings` and open `Player Settings` at bottom left
4. Change `Product Name` to `App-V`. Expland `Icon`, change `Short Name`.  Expand `Publishing Settings`, change all `App-P` to `App-V`. There shoud be 4 changes in total
