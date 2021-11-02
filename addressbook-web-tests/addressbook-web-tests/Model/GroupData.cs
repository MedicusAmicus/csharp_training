namespace WebAddressbookTests
{
    public class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";
        private string group_number;

        public GroupData(string name)
        {
            this.name = name;
        }
        public GroupData (string name, string header, string footer)
            {
            this.name = name;
            this.header = header;
            this.footer = footer;
            }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
        public string Group_number
        {
            get
            {
                return group_number;
            }
            set
            {
                group_number = value;
            }
        }
    }
}
