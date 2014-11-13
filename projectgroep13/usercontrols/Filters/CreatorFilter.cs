using ProjectGroep13;

namespace GUI_Bits
{
    class CreatorFilter : TextFilter
    {
    
        public CreatorFilter() : this(""){}
        public CreatorFilter(string owner)
        {
            this.Text = "Created by";
            this.Value = owner;
        }

        public override void UpdateFilters()
        {
            Filters.Instance.Creator = Value;
        }

    }
}