using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugar
{
    public struct TransitionRule
    {
        public int ToIndex;
        public Func<bool> Condition;
        public TransitionRule(int toIndex, Func<bool> condition) {
            ToIndex = toIndex;
            Condition = condition;
        }

    }
    public class Image
    {
        public Vector2 Position, Scale;
        public Color Color;
        public Texture2D Texture;
        public float LayerDepth;
        public Image(Texture2D texture, Vector2 position, Vector2 scale, float layer)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            LayerDepth = layer;
            Color = Color.White;
        }
        public Image(Texture2D texture, Vector2 position, Vector2 scale, float layer, Color color)
        {
            Texture = texture;
            Position = position;
            Scale = scale;
            LayerDepth = layer;
            Color = color;
        }

    }
    public class AABB {
        //position is left top
        public Vector2 Position, Size;
        //boolean for collision function to resolve overlaps automatically
        public bool Resolve;
        public AABB(Vector2 position, Vector2 size, bool resolve) { 
            Position = position-size/2;
            Size = size;
            Resolve = resolve;
        }
        public bool TestPoint(Vector2 point)
        {
            if(Position.X > point.X || Position.X + Size.X < point.X) return false;
            if(Position.Y > point.Y || Position.Y + Size.Y < point.Y) return false;
            return true;
        }
    }
    public class Entity
    {
        //position is centered, Size is the Actual size
        public Vector2 Position, Size;
        public Vector2 Velocity, Forces, Movement = Vector2.Zero;
        public float Weight, Gravity, AttackCooldown, UtilityCooldown, SpecialCooldown;
        public Func<int> AIUpdate, UtilityFunc, AttackFunc, SpecialFunc;
        public int MaxHealth, Health;
        private List<SpriteAnimation> Animations;
        private SpriteAnimation CurrentAnim;
        public bool Grounded = true;
        public Color Color;
        private int InvulnFrames;
        private bool Unable, Dead = false;
        //it's collider
        public AABB collider;
        public Entity(Vector2 position, Vector2 size, float weight, float gravity, List<SpriteSheet> animationSources) {
            Position = position;
            Size = size;
            Weight = weight;
            Gravity = gravity;
            //0 idle, 1 walk, 2 jump, 3 fall, 4 attack, 5 utility, 6 special, 7 death
            int[] durationProfile = {500,500,500,500,500,1000,1000};
            bool[] loopProfile = {true,true,false,true,false,false,false,false};
            for(int i = 0; i < 8; i++)
            {
                Animations.Add(new SpriteAnimation(animationSources[i], durationProfile[i], loopProfile[i], Size));
            }
            CurrentAnim = Animations[0];
            collider = new AABB(Position,Size,true);
        }
        public void Render(SpriteBatch sp)
        {
            sp.Draw(CurrentAnim.Source.Texture, Position, CurrentAnim.GetCurrentFrame(), Color, 0f, CurrentAnim.FrameCenter, CurrentAnim.Scale, SpriteEffects.None, 0f);
        }
        public void AddForce(Vector2 incomingForce)
        {
            Forces += incomingForce / Weight;
        }
        public void Update(int miliseconds)
        {
            AIUpdate.Invoke();
            float planc = miliseconds / 1000f;

            CheckGround();

            Velocity += Forces*planc;
            Forces = Vector2.Zero;
            Velocity.Y += Gravity*planc;
            Velocity.Y = Grounded ? 0 : Velocity.Y;
            Position += Velocity * planc;
            Position.X += Movement.X * planc;

            if (InvulnFrames == 0) CurrentAnim.Play();
            else InvulnFrames--;
            AdvanceAnimation(miliseconds);
        }
        public void Jump()
        {
            if (Unable) return;
            if (!Grounded) return;
            CurrentAnim.Reset();
            CurrentAnim = Animations[2];
            Velocity.Y = 0.1f;
            CurrentAnim.Play();
        }
        public void DoAttack()
        {
            if (Unable) return;
            AttackFunc.Invoke();
            CurrentAnim.Reset();
            CurrentAnim = Animations[4];
            CurrentAnim.Play();
        }
        public void DoUtility()
        {
            if (Unable) return;
            UtilityFunc.Invoke();
            CurrentAnim.Reset();
            CurrentAnim = Animations[4];
            Movement.X = 0;
            CurrentAnim.Play();
        }
        public void DoSpecial()
        {
            if (Unable) return;
            SpecialFunc.Invoke();
            CurrentAnim.Reset();
            CurrentAnim = Animations[6];
            CurrentAnim.Play();
        }
        public void Hit(int damage)
        {
            Health -= damage;
            InvulnFrames = 20;
            CurrentAnim.Pause();
            if (Health <= 0)
            {
                //die
                Dead = true;
                CurrentAnim = Animations[7];
                CurrentAnim.Play();
                //disable AI
                AIUpdate = () => { return 0; }; 
            }
        }
        private void AdvanceAnimation(int miliseconds)
        {
            if(!CurrentAnim.Playing && Velocity.Y > 0)
            {
                CurrentAnim.Reset();
                CurrentAnim = Animations[3];
                CurrentAnim.Play();
            }
            CurrentAnim.AdvanceByMilis(miliseconds);
        }
        private void CheckGround()
        {
            //funny;
        }
    }
}
