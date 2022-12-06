using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RosSharp.RosBridgeClient
{
    public class SpherePoint : MonoBehaviour
    {

        [SerializeField] private RandomMove script;
        [SerializeField] private int sphereNum;

        public void setUserPoint()
        {
            script.userPoint = sphereNum;
        }
    }
}