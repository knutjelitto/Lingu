using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public abstract class Item<TItem>
        where TItem : Item<TItem>
    {
        protected Item(Core core)
        {
            Core = core;
            Num = -1;
        }

        public Core Core { get; }
        public int Num { get; set; }

        public bool IsComplete => Core.IsComplete;
        public Symbol PostDot => Core.PostDot;
        public int Id => Core.Id;
        public abstract TItem Next();

        protected string Action()
        {
            if (IsComplete)
            {
                return $"reduce {Core.Production.Nonterminal.Name}";
            }
            if (PostDot is Terminal)
            {
                return $"shift {Num}";
            }
            return $"goto {Num}";
        }
    }
}
