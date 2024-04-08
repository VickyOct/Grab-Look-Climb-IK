using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour
{
    public bool useIK;

    public bool leftHandIK; 
    public bool rightHandIK;

    public Vector3 leftHandPos; 
    public Vector3 rightHandPos;

    public Vector3 leftHandOffset;
    public Vector3 rightHandoffset;
    public Quaternion leftHandRot; 
    public Quaternion rightHandRot;
    private Animator anim;

    void Start() 
    {
        anim = this.GetComponent<Animator>(); 
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit LHit;
        RaycastHit RHit;

        //LeftHandIKCheck
        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), out LHit, 1f))
        {
            leftHandIK = true;
            leftHandPos = LHit.point - leftHandOffset;
            leftHandRot = Quaternion.FromToRotation(Vector3.forward, LHit.normal);
        }
        else
        {
            leftHandIK = false;
        }
        //RightHandIKCheck
        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), out RHit, 1f))
        {
            rightHandIK = true;
            rightHandPos = RHit.point - rightHandoffset;
            rightHandRot = Quaternion.FromToRotation(Vector3.forward, RHit.normal);
        }
        else
        {
            rightHandIK = false;
        }
    }

        void Update()
        {
            Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), Color.green);
            Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), Color.green);
        }
            
            void OnAnimatorIK()
            {
                if (useIK)
                {
                    if (leftHandIK)
                    {
                        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos);
                        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);

                        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandRot);
                        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
                    }
                    if (rightHandIK)
                    {
                        anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPos);
                        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);

                        anim.SetIKRotation(AvatarIKGoal.RightHand, leftHandRot);
                        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
                    }
                }
            }

 }

