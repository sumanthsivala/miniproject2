using Microsoft.EntityFrameworkCore;
using miniproject2.Models.Domain;

namespace miniproject2.studentdata
{
	public class studentcontext : DbContext
	{
		public studentcontext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<student> students { get; set; }

	}
}
