namespace CustomLinkedList
{
    public class CustomLinkedList<T>
    {
        public ListItem<T> First { get; set; }

        public ListItem<T> Last
        {
            get
            {
                if (this.First == null)
                {
                    return null;
                }

                var nextElement = this.First;

                if (nextElement.NextItem == null)
                {
                    return nextElement;
                }

                while (nextElement.NextItem != null)
                {
                    nextElement = nextElement.NextItem;
                }

                return nextElement;
            }
        }

        public void Add(ListItem<T> listItem)
        {
            if (this.First == null)
            {
                this.First = listItem;
                return;
            }

            this.Last.NextItem = listItem;
        }
    }
}
