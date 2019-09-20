using System;

namespace TheatricalPlayersRefactoringKata
{
    public class Play
    {
        private string _name;
        private string _type;

        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }

        public Play(string name, string type) {
            this._name = name;
            this._type = type;
        }

        internal int CalculateAmount(int audience)
        {
            int thisAmount = 0;
            switch (Type)
            {
                case "tragedy":
                    thisAmount = 40000;
                    if (audience > 30)
                    {
                        thisAmount += 1000 * (audience - 30);
                    }
                    break;
                case "history":
                    thisAmount = 20000;
                    if (audience > 35)
                    {
                        thisAmount += 1000 * (audience - 35);
                    }
                    break;
                case "pastoral":
                    thisAmount = 45000;
                    if (audience > 30)
                    {
                        thisAmount += 1000 * (audience - 30);
                    }
                    break;
                case "comedy":
                    thisAmount = 30000;
                    if (audience > 20)
                    {
                        thisAmount += 10000 + 500 * (audience - 20);
                    }
                    thisAmount += 300 * audience;
                    break;
                default:
                    throw new Exception("unknown type: " + Type);
            }
            return thisAmount;
        }
    }
}
