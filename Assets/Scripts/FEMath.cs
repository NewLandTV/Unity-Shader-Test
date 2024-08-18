public static class FEMath
{
    public static float Lerp(float s, float e, float t) => s * (1.0f - t) + e * t;
}
