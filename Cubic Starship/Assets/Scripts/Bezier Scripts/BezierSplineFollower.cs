﻿using UnityEngine;
using System.Collections;

//Testing
public enum SplineFollowMode
{
    Once,
    Loop,
    PingPong
}

public class BezierSplineFollower : MonoBehaviour
{
    public SplineFollowMode mode;
    public BezierSpline b_spline;

    public float duration;
    public bool lookForward;

    private float progress;
    private bool goingForward = true;


	//TODO: - Eric - Create operator overload and copy constructor




	private void Update()
    {
        if (progress == 0)
        {
            this.gameObject.SetActive(true);
        }
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode == SplineFollowMode.Once)
                {
                    progress = 1f;
                }
                else if (mode == SplineFollowMode.Loop)
                {
                    progress -= 1f;
                }
                else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = b_spline.GetPoint(progress);
        transform.position = position;	//11-21-15 - Eric - changed this from localPosition to position so it can follow whoever the parent will be.
        if (lookForward)
        {
            transform.LookAt(position + b_spline.GetDirection(progress));
        }
    }
}





// LEGACY CODE FROM 11/10/15 BY PAUL - Eric
//
//using UnityEngine;
//using System.Collections;

////Testing
//public enum SplineFollowMode
//{
//	Once,
//	Loop,
//	PingPong
//}

//public class BezierSplineFollower : MonoBehaviour
//{
//	public SplineFollowMode mode;
//	public BezierSpline b_spline;

//	public float duration;
//	public bool lookForward;

//	private float progress;
//	private bool goingForward = true;

//	private void Update()
//	{
//		if (progress == 0)
//		{
//			this.gameObject.SetActive(true);
//		}
//		if (goingForward)
//		{
//			progress += Time.deltaTime / duration;
//			if (progress > 1f)
//			{
//				if (mode == SplineFollowMode.Once)
//				{
//					progress = 1f;
//				}
//				else if (mode == SplineFollowMode.Loop)
//				{
//					progress -= 1f;
//				}
//				else
//				{
//					progress = 2f - progress;
//					goingForward = false;
//				}
//			}
//		}
//		else
//		{
//			progress -= Time.deltaTime / duration;
//			if (progress < 0f)
//			{
//				progress = -progress;
//				goingForward = true;
//			}
//		}

//		Vector3 position = b_spline.GetPoint(progress);
//		transform.localPosition = position;
//		if (lookForward)
//		{
//			transform.LookAt(position + b_spline.GetDirection(progress));
//		}
//	}
//}
