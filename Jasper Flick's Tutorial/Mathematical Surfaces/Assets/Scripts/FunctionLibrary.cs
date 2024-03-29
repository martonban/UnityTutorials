using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibary
{
    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName
    {
        Wave,
        MultiWave,
        Ripple,
        Sphere,
        AnimatedSphere,
        SphereWithHorizontalBands,
        RotatingTwistedSphere,
        Torus,
        TwistingTorus,
        Water
    }

    static Function[] functions =
    {
        Wave, MultiWave, Ripple, Sphere, AnimatedSphere, SphereWithHorizontalBands,
        RotatingTwistedSphere, Torus, TwistingTorus, Water
    };

    public static Function GetFunction(FunctionName name)
    {
        return functions[(int)name];
    }

    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + v + t));
        p.z = v;
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        float d = Sqrt(u * u + v * v);
        p.y = Sin(PI * (4f * d - t));
        p.y /= (1f + 10f * d);
        p.z = v;
        return p;
    }
    
    // I wanted a water like thing to do but this is kind of cool :D
    /*public static Vector3 Water(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        float omega1 = (2f * PI) / 5f;
        float omega2 = (2f * PI) / 2f;
        float A = .03f; 
        p.y = A * Sin(omega1 * t * v - 2);
        p.y += A * Sin(omega2 * t * u * v - 2);
        p.z = v;
        return p;
    }
    */
    
    public static Vector3 Water(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        float omega = (2f * PI) / 5f;
        float vA = .1f;
        float uA = .08f;
        p.y = vA * Sin(omega * t - 2 * v);
        p.y += uA * Sin(omega * t - 0.5f * u);
        p.y /= 2.0f;
        p.z = v;
        return p;
    }

public static Vector3 Sphere(float u, float v, float t)
{
    float r = Cos(0.5f * PI * v);
    Vector3 p;
    p.x = r * Sin(PI * u);
    p.y = Sin(PI * 0.5f * v);
    p.z = r * Cos(PI * u);
    return p;
}

public static Vector3 AnimatedSphere(float u, float v, float t)
{
    float r = 0.5f + 0.5f * Sin(PI * t);
    float s = r * Cos(0.5f * PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r * Sin(PI * 0.5f * v);
    p.z = s * Cos(PI * u);
    return p;
}

public static Vector3 SphereWithHorizontalBands(float u, float v, float t)
{
    float r = 0.9f + 0.1f * Sin(8f * PI * v);
    float s = r * Cos(0.5f * PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r * Sin(PI * 0.5f * v);
    p.z = s * Cos(PI * u);
    return p;
}

public static Vector3 RotatingTwistedSphere(float u, float v, float t)
{
    float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
    float s = r * Cos(0.5f * PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r * Sin(PI * 0.5f * v);
    p.z = s * Cos(PI * u);
    return p;
}

public static Vector3 Torus(float u, float v, float t)
{
    float r1 = 0.75f;
    float r2 = 0.25f;
    float s = r1 + r2 * Cos(PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r2 * Sin(PI * v);
    p.z = s * Cos(PI * u);
    return p;
}

public static Vector3 TwistingTorus(float u, float v, float t)
{
    float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
    float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
    float s = r1 + r2 * Cos(PI * v);
    Vector3 p;
    p.x = s * Sin(PI * u);
    p.y = r2 * Sin(PI * v);
    p.z = s * Cos(PI * u);
    return p;
}
}