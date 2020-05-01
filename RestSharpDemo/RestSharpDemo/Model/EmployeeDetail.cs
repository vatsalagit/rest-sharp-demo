namespace RestSharpDemo.Model
{
    public class EmployeeDetail
    {
        public string name { get; set; }
        public string salary { get; set; }
        public string age { get; set; }
        public string id { get; set; }
    }

    public class CreatEmployeeResponse
    {
        public string status { get; set; }

        public EmployeeDetail data { get; set; }
    }
}