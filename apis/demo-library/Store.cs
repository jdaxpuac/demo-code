namespace demo_library
{
    public class Store
    {
        List<Item> items;
        public Store()
        {
            items = new List<Item>();
        }

        public Item GetById(int id)
        {
            return items.FirstOrDefault(i => i.id == id);
        }

        public void AddItem(Item newItem)
        {   
            Item exist = GetById(newItem.id);   
            if(exist != null)
            {
                items.Add(exist);
            }
        }

        public void RemoveItem(int id)
        {
            Item itm = GetById(id);
            items.Remove(itm);
        }

    }
}
