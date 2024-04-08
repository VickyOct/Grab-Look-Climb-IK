using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LookIK
{
    using Definition;
    using Utility;

    public class LookIK : MonoBehaviour
    {
        [SerializeField] private BodyPart head;
        [SerializeField] private BodyPart[] spines;

        [SerializeField] private Transform target;
        [SerializeField] private bool isSmoothLookAt = false;
        [SerializeField, Range(0f, 1f)] private float smoothTime = 0.1f;
        private Vector3 smoothTarget;

        public Transform Target
        {
            get { return target; }
            set { target = value; }
        }

        public bool IsSmoothLookAt
        {
            get { return isSmoothLookAt; }
            set { isSmoothLookAt = value; }
        }

        public float SmoothTime
        {
            get { return smoothTime; }
            set { smoothTime = value; }
        }

        public Vector3 SmoothTarget
        {
            get { return smoothTarget; }
        }

        private void SmoothMovement()
        {
            if (isSmoothLookAt && target)
                smoothTarget = Vector3.Lerp(smoothTarget, target.position, smoothTime);
        }

        private void Update()
        {
            SmoothMovement();
        }

        private void LateUpdate()
        {
            Aim();
        }

        private void OnDrawGizmos()
        {
            Gizmos();
        }
        public BodyPart Head
        {
            get { return head; }
        }

        public BodyPart[] Spines
        {
            get { return spines; }
        }

        protected void Aim()
        {
            if (spines.Length > 0)
            {
                foreach (BodyPart spine in spines)
                {
                    if (spine.Bone && Target)
                    {
                        if (IsSmoothLookAt)
                            spine.Bone.LookAt3D(SmoothTarget - spine.PositionOffset
                                , spine.RotationOffset);
                        else
                            spine.Bone.LookAt3D(Target.position - spine.PositionOffset
                                , spine.RotationOffset);
                        spine.Bone.CheckClamp3D(spine.LimitRotation, spine.Rotation);
                    }
                }
            }

            if (head.Bone && Target)
            {
                if (IsSmoothLookAt)
                    head.Bone.LookAt3D(SmoothTarget - head.PositionOffset, head.RotationOffset);
                else
                    head.Bone.LookAt3D(Target.position - head.PositionOffset, head.RotationOffset);

                head.Bone.CheckClamp3D(head.LimitRotation, head.Rotation);
            }
        }

        protected void Gizmos()
        {
#if UNITY_EDITOR

            if (head.Bone && Target && head.Gizmos.IsShow)
            {
                UnityEngine.Gizmos.color = head.Gizmos.Color;
                UnityEngine.Gizmos.DrawLine(head.Bone.position
                    + head.PositionOffset, Target.position);
            }

            if (spines != null)
            {
                foreach (BodyPart spine in spines)
                {
                    if (spine.Bone && Target && spine.Gizmos.IsShow)
                    {
                        UnityEngine.Gizmos.color = spine.Gizmos.Color;
                        UnityEngine.Gizmos.DrawLine(spine.Bone.position
                            + spine.PositionOffset, Target.position);
                    }
                }
            }

#endif
        }
    }
}