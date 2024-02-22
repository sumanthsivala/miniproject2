namespace miniproject2.Models.Domain
{
	public class student
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public string course { get; set; }
		public double percentage { get; set; }
	}
}
