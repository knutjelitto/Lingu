#nullable enable

using Lingu.Grammars;

namespace Lingu.LR
{
    public abstract class Item
    {
        protected Item(Core dotted, Action? action = null)
        {
            Core = dotted;
            Action = action;
        }

        public Core Core { get; }
        public Action? Action { get; private set; }

        public bool IsComplete => Core.IsComplete;
        public Core Next => Core.Next;
        public Symbol PostDot => Core.PostDot;
        public int Id => Core.Id;

        public class Patch
        {
            public Patch(Item item, System.Action<int> make)
            {
                Item = item;
                Make = make;
            }

            public Item Item { get; }
            public System.Action<int> Make { get; }

            public void Do(int state)
            {
                Make(state);
            }
        }
    }
}
