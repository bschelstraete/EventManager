using GUI_Bits;

namespace ProjectGroep13
{
    public partial class UserOptionControl : InfoContainerList
    {
        private ButtonContainer create = new ButtonContainer("Create new event");
        private ButtonContainer mine = new ButtonContainer("Show my events");
        private ButtonContainer joined = new ButtonContainer("Show joined events");
        private ButtonContainer logout = new ButtonContainer("Log out");

        public UserOptionControl()
        {
            InitializeComponent();

            this.Add(create);
            this.Add(mine);
            this.Add(joined);
            this.Add(logout);
        }

        public ButtonContainer LogoutButton
        {
            get { return logout; }
        }

        public ButtonContainer CreateButton
        {
            get { return create; }
        }

        public ButtonContainer ShowMineButton
        {
            get { return mine; }
        }

        public ButtonContainer ShowJoinedButton
        {
            get { return joined; }
        }

    }
}
