using Lingu.Grammars;

#nullable enable

namespace Lingu.LR
{
    public abstract class Item<TItem>
        where TItem : Item<TItem>
    {
        protected Item(Core core, bool inKernel)
        {
            Core = core;
            InKernel = inKernel;
            ToState = -1;
        }

        public Core Core { get; }
        public bool InKernel { get; }
        public int ToState { get; set; }

        public bool IsComplete => Core.IsComplete;
        public Symbol PostDot => Core.PostDot;
        public int Id => Core.Id;
        public abstract TItem Next(bool inKernel);

        public string Action()
        {
            if (IsComplete)
            {
                return $"reduce {Core.Production.Nonterminal.Name}";
            }
            if (PostDot is Terminal)
            {
                return $"shift {ToState}";
            }
            return $"goto {ToState}";
        }
    }
}
