using System.Collections.Generic;

namespace Venminder.Classes
{
    public class Frame
    {
        //list of items representing how many throws per turn
        public List<int> ThrowList = new List<int>() { 0, 0 };
        public bool IsSpare { get; set; }      
        public int Score { get; set; }
        public int PinsRemaining { get; set; }
        public void BonusThrow(Frame frame)
        {
            frame.PinsRemaining = 10;
            frame.ThrowList.Add(0);            
        }        
    }
}
