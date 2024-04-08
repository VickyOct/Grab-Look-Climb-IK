using UnityEngine;
using System;

namespace LookIK.Definition
{
    [Serializable]
    public class BodyPart
    {
        public Transform Bone;
        public Vector3 PositionOffset;
        public Vector3 RotationOffset;
        public LimitRotation LimitRotation;
        public Gizmos Gizmos;
        public Vector3 Rotation { get; set; }
    }
    [Serializable]
    public class LimitRotation
    {
        public LimitRotationAxis XAxis;
        public LimitRotationAxis YAxis;
        public LimitRotationAxis ZAxis;
    }
    [Serializable]
    public class LimitRotationAxis
    {
        public bool IsLimitRotation;
        public float Min;
        public float Max;
    }
    [Serializable]
    public class Gizmos
    {
        public bool IsShow;
        public Color Color = Color.white;
    }
}
