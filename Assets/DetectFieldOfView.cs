using UnityEditor;
using UnityEngine;

public class DetectFieldOfView : MonoBehaviour
{
    [SerializeField] GameObject _gameObject;
    
    [SerializeField] float _coneDistance = 1f;
    [SerializeField] float _coneAngle = 45f;
    
    void Update()
    {
        IsInFieldOfView();
    }
    bool IsInFieldOfView()
    {
        Vector3 directioin = _gameObject.transform.position - transform.position;
        Vector3 forwardA = transform.forward.normalized;
        float dotProduct = MathFunc.Dot(directioin.normalized, forwardA);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        float distance = directioin.magnitude;

        //print("Distance: " + distance);
        if (distance <= _coneDistance && angle <= _coneAngle / 2f)
        {
            return true;
        }

        return false;
    }
    
    void OnDrawGizmos()
    {
        DrawTriangle(transform.position, transform.forward, _coneAngle, _coneDistance, IsInFieldOfView() 
            ? Color.green 
            : Color.red);
    }

    void DrawTriangle(Vector3 origin, Vector3 direction, float angle, float length, Color color)
    {
        Gizmos.color = color;

        Vector3 vertexA = origin;
        Vector3 vertexB = origin + Quaternion.Euler(0f, -angle / 2f, 0f) * direction.normalized * length;
        Vector3 vertexC = origin + Quaternion.Euler(0f, angle / 2f, 0f) * direction.normalized * length;

        float thickness = 2f;
        
        Gizmos.DrawLine(vertexA, vertexB);
        Gizmos.DrawLine(vertexB, vertexC);
        Gizmos.DrawLine(vertexC, vertexA);
        
        // DrawThickLine(vertexA, vertexB, thickness);
        // DrawThickLine(vertexB, vertexC, thickness);
        // DrawThickLine(vertexC, vertexA, thickness);
    }
    
    void DrawThickLine(Vector3 start, Vector3 end, float thickness)
    {
        Camera c = Camera.current;
        if (c == null) 
            return;

        if (c.clearFlags == CameraClearFlags.Depth || c.clearFlags == CameraClearFlags.Nothing)
        {
            return;
        }

        var prevZTest = Handles.zTest;
        Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

        Handles.color = Gizmos.color;
        Handles.DrawAAPolyLine(thickness * 10, start, end);

        Handles.zTest = prevZTest;
    }
}
