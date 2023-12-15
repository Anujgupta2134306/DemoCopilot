namespace DemoCopilot.Model.Domain
{
    public class Player
    {
        //create variable having fields name as Id,Name,Age,Email,ContactNo,Gender.

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }

        public int ContactNo { get; set; }
        public string Gender { get; set; }

    }
}
