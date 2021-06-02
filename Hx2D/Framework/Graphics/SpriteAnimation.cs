using System;
using System.Collections.Generic;

namespace Hx2D.Framework.Graphics
{
    public class SpriteAnimation
    {
        public string Name;
        
        public bool IsPlaying;
        public bool IsLooping;

        public TimeSpan LastTimeSpan;

        public LinkedList<SpriteAnimationStep> AnimationSteps;

        public SpriteAnimation()
        {
            AnimationSteps = new LinkedList<SpriteAnimationStep>();
        }

        public void AddAnimationStep(SpriteAnimationStep animationStep)
        {
            AnimationSteps.AddLast(animationStep);
        }
        
    }

    public struct SpriteAnimationStep
    {

        public double Duration; // Duration in ms
        public int Index; // Index on the sprite sheet

        public SpriteAnimationStep(double duration, int index)
        {
            Duration = duration;
            Index = index;
        }

    }
    
}