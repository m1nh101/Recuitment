using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database;

public class DefaultDataMigration
{
  private readonly AppDbContext _context;

	public DefaultDataMigration(AppDbContext context)
	{
		_context = context;
	}

	public DefaultDataMigration MigrateLevel()
	{
		if (!_context.Levels.Any())
		{
			Level intern = new() { Name = "Intern", Status = SharedKernel.Enums.Status.Active };
			Level junior = new() { Name = "Junior ", Status = SharedKernel.Enums.Status.Active };
			Level senior = new() { Name = "Senior", Status = SharedKernel.Enums.Status.Active };
			Level middle = new() { Name = "Middle", Status = SharedKernel.Enums.Status.Active };
			Level expert = new() { Name = "Expert", Status = SharedKernel.Enums.Status.Active };

			_context.AddRange(intern, junior, senior, middle, expert);
			_context.SaveChanges();
		}
		return this;
	}
	public DefaultDataMigration MigratePosition()
	{
		if (!_context.Positions.Any())
		{
			List<Position> positions = new()
			{
				new() { Name = "Intern", Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Developer", Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Senior", Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Leader", Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "PM", Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Comtor", Status = SharedKernel.Enums.Status.Active },
				new() { Name = "HR", Status = SharedKernel.Enums.Status.Active },
				new() { Name = "Accounting", Status = SharedKernel.Enums.Status.Active }
			};

			_context.Positions.AddRange(positions);
			_context.SaveChanges();
		}

		return this;
	}
	public DefaultDataMigration MigrateSkillTag()
	{
		if (!_context.SkillTags.Any())
		{
			List<SkillTag> skillTags = new()
			{
				new() { Name = "Kỹ năng mở rộng", Type = SharedKernel.Enums.SkillTagType.Hard, Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Mở rộng", Type = SharedKernel.Enums.SkillTagType.Hard, Status = SharedKernel.Enums.Status.Active  },
				new() { Name = "Ngôn ngữ", Type = SharedKernel.Enums.SkillTagType.Hard, Status = SharedKernel.Enums.Status.Active  }
			};

			_context.SkillTags.AddRange(skillTags);
			_context.SaveChanges();
		}

		return this;
	}
	public DefaultDataMigration MigrateDepartment()
	{
		if (!_context.Departments.Any())
		{
			Department system = new() { Name = "Hệ thống", Location = "System", Status = SharedKernel.Enums.Status.Active };
			Department technique = new() { Name = "Kỹ thuật", Location = "System", Status = SharedKernel.Enums.Status.Active };
			_context.Departments.AddRange(system, technique);
			_context.SaveChanges();
		}

		return this;
	}
	public DefaultDataMigration MigrateRole(RoleManager<IdentityRole> roleManager)
	{
		if (!roleManager.Roles.Any())
		{
			List<IdentityRole> roles = new()
			{
				new IdentityRole("Admin"),
				new IdentityRole("Director"),
				new IdentityRole("HR"),
				new IdentityRole("PMO"),
				new IdentityRole("Leader"),
				new IdentityRole("SubLeader"),
				new IdentityRole("Developer"),
				new IdentityRole("Intern"),
			};

			Task.Run(async () =>
			{
				foreach (var role in roles)
					await roleManager.CreateAsync(role);
			});
		}

		return this;
	}
	public DefaultDataMigration MigrateSystemUser(UserManager<User> userManager, IConfiguration configuration)
	{
		if (!userManager.Users.Any())
		{
      string password = configuration["SU:PWD"] ?? "ROOT@syst3m";
			string username = configuration["SU:UID"] ?? "admin";

			if (string.IsNullOrEmpty(username))
				username = "admin";

			if (string.IsNullOrEmpty(password))
				password = "ROOT@syst3m";

      User user = new()
			{
				UserName = username,
				Name = "System user",
				EmailConfirmed = true,
				WorkType = SharedKernel.Enums.WorkType.FullTime,
				Status = SharedKernel.Enums.Status.Active,
				DepartmentId = 1,
				Id = "d1d99d84-f944-43c2-872a-8e66386ab936"
      };

			Task.Run(async () =>
			{
				await userManager.CreateAsync(user, password);
				await userManager.AddToRoleAsync(user, "admin");
			});
		}

		return this;
	}
}