using UnityEngine;

namespace PingPong
{
    public static class CameraExtensions
    {
        public static Vector3 LDCornerToWorld(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        }

        public static Vector3 RDCornerToWorld(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        }

        public static Vector3 LUCornerToWorld(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        }

        public static Vector3 RUCornerToWorld(this Camera camera)
        {
            return camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        }

        public static float RightBorder(this Camera camera)
        {
            return camera.RDCornerToWorld().x;
        }

        public static float LeftBorder(this Camera camera)
        {
            return camera.LDCornerToWorld().x;
        }
    }
}
