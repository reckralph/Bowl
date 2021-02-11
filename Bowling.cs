using System;
using System.Collections.Generic;

namespace Venminder.Classes
{
    public class Bowling
    {               
        public const int MaxFrameCount = 10;
        public List<Frame> Frames { get; set; } = new List<Frame>();
        public int Score;

        public Bowling()
        {
            LoadFrames();
        }
        public void Roll (int pinsKnockedOver, Frame frame)
        {            
            if (pinsKnockedOver == MaxFrameCount && !frame.IsSpare)
            {
                //frame.PinsRemaining = MaxFrameCount;                
                Console.WriteLine($"You rolled a Strike!! : Score {frame.Score}");
            }
            else if (frame.PinsRemaining >= 0)
            {
                if (pinsKnockedOver > frame.PinsRemaining || pinsKnockedOver > MaxFrameCount)
                {
                    Console.WriteLine("Please enter a valid number of pins knocked over.");
                    return;
                }         
                
                frame.IsSpare = true;
                frame.PinsRemaining -= pinsKnockedOver;                               
            }

            frame.Score += pinsKnockedOver;  
            if(frame.Score == MaxFrameCount)
            {
                frame.BonusThrow(frame);
                frame.PinsRemaining = MaxFrameCount;
                Console.WriteLine($"You rolled a Strike!! : Score {frame.Score}");
            }
        }

        public void LoadFrames()
        {
            for (int i = 0; i <= MaxFrameCount - 1; i++)
            {
                this.Frames.Add(new Frame() {PinsRemaining = MaxFrameCount });
            }
        }         
    }    
}
