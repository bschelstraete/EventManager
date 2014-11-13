using ProjectGroep13;

namespace GUI_Bits
{
    class LocationFilter : TextFilter
    {
        public LocationFilter() : this(""){}
        public LocationFilter(string place)
        {
            this.Text = "Takes place at";
            this.Value = place;
        }

        public override void UpdateFilters()
        {
            Filters.Instance.Location = Value;
        }
    }
}