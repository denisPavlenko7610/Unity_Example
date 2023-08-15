using UnityEngine;
using Cysharp.Threading.Tasks;
using DefaultNamespace;

public class RotationController : MonoBehaviour
{
    [SerializeField] Transform targetObject;

    void Start()
    {
        RotateToObjectAsync().Forget();
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
}