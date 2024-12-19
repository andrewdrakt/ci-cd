namespace observatory.code
{
    public class CurrentUser
    {
        /*        public string Name { get; set; }
                public string Department { get; set; }
        */

        private static string FIO;
        private static string department;

        public string Name
        {
            get { return FIO; }
            set { FIO = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
    }
}
