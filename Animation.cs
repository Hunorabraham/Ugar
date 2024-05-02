using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ugar
{
    public class SpriteAnimation
    {
        //Duration is in miliseconds, FrameCounter is divided by FPS then floored for current frame index and advanced by elapsed miliseconds each game frame
        public int Frames, Duration, FrameCounter, FrameDuration;
        public bool Loop, Playing;
        public SpriteSheet Source;
        public Vector2 Scale = Vector2.One;
        public Vector2 FrameCenter;
        private Rectangle SourceRect;
        public SpriteAnimation(SpriteSheet source, int duration, bool loop)
        {
            Source = source;
            Frames = source.Columns * source.Rows - source.Blanks;
            Duration = duration;
            Loop = loop;
            FrameCounter = 0;
            FrameDuration = Duration / Frames;
            SourceRect = new Rectangle(0,0,Source.FrameWidth,Source.FrameHeingt);
            FrameCenter = new Vector2(Source.FrameWidth /2,Source.FrameHeingt/2);
            Playing = false;
        }
        public SpriteAnimation(SpriteSheet source, int duration, bool loop, Vector2 DestinationSize)
        {
            Source = source;
            Frames = source.Columns * source.Rows - source.Blanks;
            Duration = duration;
            Loop = loop;
            FrameCounter = 0;
            FrameDuration = Duration / Frames;
            SourceRect = new Rectangle(0, 0, Source.FrameWidth, Source.FrameHeingt);
            Playing = false;
            Scale = DestinationSize / new Vector2(Source.FrameWidth, Source.FrameHeingt);
        }
        public Rectangle GetCurrentFrame() {
            if(!Playing) return SourceRect;//if we aren't playing we don't have to update the frame
            int currentFrame = FrameCounter / FrameDuration;
            SourceRect.X = (currentFrame % Source.Columns) * Source.FrameWidth;
            SourceRect.Y = (currentFrame / Source.Rows) * Source.FrameHeingt;
            return SourceRect;
        }
        public void Play()
        {
            Playing = true;
        }
        public void Pause()
        {
            Playing=false;
        }
        public void Reset() {
            Playing = false;
            FrameCounter = 0;
        }
        public void Restart()
        {
            Playing = true;
            FrameCounter = 0;
        }
        public void AdvanceByMilis(int miliseconds)
        {
            //check if the animation is paused
            if(!Playing) return;
            FrameCounter += miliseconds;
            //reset FrameCounter if it reaches duration
            FrameCounter = FrameCounter == Duration ? 0 : FrameCounter;
            //stop playing if looping is disabled and we're at the end
            Playing = Loop || FrameCounter != 0;
        }
    }
    public class SpriteSheet
    {
        public Texture2D Texture;
        public int Rows, Columns, FrameHeingt, FrameWidth, Blanks;
        public SpriteSheet(Texture2D texture, int rows, int columns, int blanks) {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Blanks = blanks;
            FrameHeingt = Texture.Height/Rows;
            FrameWidth = Texture.Width/Columns;
        }
    }
}
