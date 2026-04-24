using UnityEngine;

public static class LineUtility
{
    public static void LerpLine(LineRenderer line, Vector3 start, Vector3 end, float t, float padding = -0.02f, float width = 0.04f, float nudgeTowardCamera = 0.02f)
    {
        t = Mathf.Clamp01(t);

        Vector3 currentEnd = Vector3.Lerp(start, end, t);

        Vector3 dir = (currentEnd - start).normalized;

        Vector3 paddedStart = start + dir * padding;
        Vector3 paddedEnd = currentEnd - dir * padding;

        Vector3 nudgedAndPaddedStart = paddedStart;
        Vector3 nudgedAndPaddedEnd = paddedEnd;

        if(Camera.main is var cam)
        {
            Vector3 toCamStartDir = (cam.transform.position - paddedStart).normalized;
            Vector3 toCamEndDir = (cam.transform.position - paddedEnd).normalized;

            nudgedAndPaddedStart = paddedStart + toCamStartDir * nudgeTowardCamera;
            nudgedAndPaddedEnd = paddedEnd + toCamEndDir * nudgeTowardCamera;
        }


        line.startWidth = width;
        line.endWidth = width;
        line.positionCount = 2;
        line.SetPosition(0, nudgedAndPaddedStart);
        line.SetPosition(1, nudgedAndPaddedEnd);
    }

    public static (Vector3 a, Vector3 b) GetFurthestPoints(Vector3[] points)
    {
        float maxDist = 0f;
        Vector3 a = points[0];
        Vector3 b = points[1];

        for(int i = 0; i < points.Length; i++)
        {
            for(int j = i + 1; j < points.Length; j++)
            {
                float dist = (points[i] - points[j]).sqrMagnitude;

                if(dist <= maxDist)
                    continue;

                maxDist = dist;
                a = points[i];
                b = points[j];
            }
        }

        return (a, b);
    }
}
