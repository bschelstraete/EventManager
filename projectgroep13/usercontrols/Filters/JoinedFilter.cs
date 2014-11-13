using ProjectGroep13;

namespace GUI_Bits
{
    class JoinedFilter : FilterListItem
    {

        public JoinedFilter()
        {
            this.Text = "I'm participanting";
        }

        public override void UpdateFilters()
        {
            Filters.Instance.Joined = true;
        }

    }
}