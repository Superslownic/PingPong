using UnityEngine;

namespace PingPong
{
    [CreateAssetMenu(fileName = "New Advanced Theme", menuName = "Themes/Advanced")]
    public class AdvancedTheme : Theme
    {
        public Color color;
        public Sprite sprite;
        public Gradient trailColor;
        public float trailLenght;
        public Color particlesColor;
        public ParticleSystem.MinMaxGradient particlesTrailColor;

        public override void Accept(IThemeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
