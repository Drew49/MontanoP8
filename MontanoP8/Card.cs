using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontanoP8
{
    public class Card
    {
        private int numRight = 0;
        private int numWrong = 0;

        public string? Answer { get; set; }
        public int CardID { get; set; } 
        public int NumRight
        {
            get {return numRight;}
            set {numRight = value; Calc(); }
            
        } 

        public int NumWrong
        {
            get {return numWrong;}
            set {numWrong = value;Calc(); }
        }
        public string? Question { get; set;}
        public float RightWrongRatio { get; set; }
        public string? Title { get; set; }
        public Card()
        {
            this.Answer = Answer;
            this.CardID = CardID;
            numRight = 0;
            numWrong = 0;
            this.Question = Question;
            this.Title = Title;
            RightWrongRatio = 0;
            Calc();
        }

        public Card(int cardID,string title, string question, string answer)
        {
            numRight = 0;
            numWrong = 0;
            RightWrongRatio = 0;
            Calc();
        }

        public void Calc()
        {
            int total = numRight + numWrong;
            //RightWrongRatio = numRight / total;
            //if(total == 0)
            //{
              //  total = 1;
            //}
        }

        public override string ToString()
        {
            return $"{Title}, {numRight}, {numWrong}, right ratio is: {RightWrongRatio}";
        }
    }
}
