﻿using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class PlayerDirectionExample : MonoBehaviour
{
    [SerializeField] Transform targetObject;
    [SerializeField] float visibilityThreshold = 0.5f;

    void Start()
    {
        RotateToObjectAsync().Forget();
        //IsLookAt().Forget();
    }

    async UniTask RotateToObjectAsync(float duration = 2f)
    {
        float startTime = Time.time;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, CalculateAngleCross(), 0f);

        while (Time.time - startTime < duration)
        {
            float progress = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, progress);
            await UniTask.Yield();
        }

        transform.rotation = targetRotation;
    }

    float CalculateAngleDot()
    {
        Vector3 targetDirection = targetObject.position - transform.position;
        float yAngle = Mathf.Acos(MathFunc.Dot(Vector3.forward, targetDirection.normalized));
        
        print("yAngle: " + yAngle * Mathf.Rad2Deg);
        return yAngle * Mathf.Rad2Deg;
    }
    
    float CalculateAngleCross()
    {
        Vector3 toTarget = targetObject.position - transform.position;
        Vector3 crossProduct = MathFunc.Cross(Vector3.forward, toTarget.normalized);
        float yAngle = Mathf.Asin(crossProduct.magnitude);
        
        print("yAngle: " + yAngle * Mathf.Rad2Deg);
        return yAngle * Mathf.Rad2Deg;
    }

    async UniTask IsLookAt()
    {
        while (true)
        {
            Vector3 toTarget = targetObject.position - transform.position;

            Vector3 forwardDirection = transform.forward.normalized;
            Vector3 toTargetNormalized = toTarget.normalized;

            float dotProduct = MathFunc.Dot(forwardDirection, toTargetNormalized);
            print("Dot product: " + dotProduct + (dotProduct >= MathF.Abs(visibilityThreshold) ? " Visible" : " Invisible"));

            await UniTask.Delay(TimeSpan.FromSeconds(0.1f));
        }
    }
}