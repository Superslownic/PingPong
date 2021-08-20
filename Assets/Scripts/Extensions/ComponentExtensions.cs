using UnityEngine;

public static class ComponentExtensions
{
    public static bool HasComponent<T>(this GameObject gameObject)
    {
        return gameObject.GetComponent<T>() != null;
    }

    public static bool HasComponent<T>(this GameObject gameObject, out T component)
    {
        component = gameObject.GetComponent<T>();
        return component != null;
    }

    public static bool HasComponent<T>(this Transform transform)
    {
        return transform.GetComponent<T>() != null;
    }

    public static bool HasComponent<T>(this Transform transform, out T component)
    {
        component = transform.GetComponent<T>();
        return component != null;
    }
}