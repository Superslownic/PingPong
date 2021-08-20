using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu(fileName = "New Standard Theme", menuName = "Themes/Standard")]
    public class StandardTheme : Theme
    {
        public Color color;
        public Sprite sprite;
        public Gradient trailColor;
        public float trailLenght;

        public override void Accept(IThemeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public abstract class Theme : ScriptableObject
    {
        public abstract void Accept(IThemeVisitor visitor);
    }
}
