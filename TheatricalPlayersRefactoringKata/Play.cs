using System;

namespace TheatricalPlayersRefactoringKata
{
    public abstract class Play
    {
        public string Name { get; }
        public string Type { get; }

        protected Play(string name, string type) {
            this.Name = name;
            this.Type = type;
        }

        public static Play CreatePlay(string name, string type)
        {
            switch (type)
            {
                case "pastoral":
                    return new PastoralPlay(name);
                case "tragedy":
                    return new TragedyPlay(name);
                case "history":
                    return new HistoryPlay(name);
                case "comedy":
                    return new ComedyPlay(name);
                default:
                    throw new Exception("unknown type: " + type);
            }
        }

        internal abstract int CalculateAmount(int audience);

        public virtual int GetVolumeCredits(int audience)
        {
            return Math.Max(audience - 30, 0);
        }
    }
}
