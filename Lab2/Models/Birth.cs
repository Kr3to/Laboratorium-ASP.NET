namespace Lab2.Models
{
    public class Birth
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsValid()
        {
            return Name != null && DateTime.Today.Year - Date.Year >= 0;
        }
        public int BirthDate()
        {

            var today = DateTime.Today;
            int age = today.Year - Date.Year;
            return age;
        }

    }
}
