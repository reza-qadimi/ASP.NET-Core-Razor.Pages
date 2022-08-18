using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public DetailsModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Pages.Admin.Users.DetailsViewModel ViewModel { get; private set; }
		// **********
		#endregion /Property(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue == false)
				{
					AddToastError
						(message: Resources.Messages.Errors.IdIsNull);
				}

				ViewModel =
					await
					DatabaseContext.Users
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.Users.DetailsViewModel
					{
						Role = current.Role.Name,
						Username = current.Username,
						FullName = current.FullName,
						IsActive = current.IsActive,
						IsSystemic = current.IsSystemic,
						Description = current.Description,
						IsProgrammer = current.IsProgrammer,
						EmailAddress = current.EmailAddress,
						IsUndeletable = current.IsUndeletable,
						InsertDateTime = current.InsertDateTime,
						UpdateDateTime = current.UpdateDateTime,
						CellPhoneNumber = current.CellPhoneNumber,
						IsProfilePublic = current.IsProfilePublic,
						AdminDescription = current.AdminDescription,
						IsEmailAddressVerified = current.IsEmailAddressVerified,
						IsCellPhoneNumberVerified = current.IsCellPhoneNumberVerified,
					})
					.AsNoTracking()
					.FirstOrDefaultAsync();

				if (ViewModel == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddPageError
					(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
		#endregion /OnGet
	}
}
