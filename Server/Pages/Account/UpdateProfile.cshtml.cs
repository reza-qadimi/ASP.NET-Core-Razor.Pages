using System.Linq;
using System.Security.Claims;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Account
{
    /// <summary>
    /// صفحه ویرایش اطلاعات کاربر توسط کاربر
    /// نیاز به لاگین بودن در سایت
    /// </summary>
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UpdateModel : Infrastructure.BasePageModelWithDatabase
    {
        public UpdateModel
            (Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
        {
            ViewModel = new();
        }

        [Microsoft.AspNetCore.Mvc.BindProperty]
        public ViewModels.Pages.Account.Users.UpdateProfileViewModel ViewModel { get; set; }

        /// <summary>
        /// دریافت اطلاعات کاربر داخل دیتابیس بر اساس نام کاربری آن
        /// و نمایش آن در فرم ویرایش اطلاعات
        /// </summary>
        /// <returns></returns>
        public
            async System.Threading.Tasks.Task OnGetAsync
            (System.Threading.CancellationToken cancellationToken)
        {
            ViewData["CultureName"] = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
            
            var userName = HttpContext.User.FindFirstValue
                (System.Security.Claims.ClaimTypes.Name); //Get UserName
            
            if (DatabaseContext is not null)
            {
                var foundedUser = await DatabaseContext
                    .Users
                    .FirstOrDefaultAsync(user => user.Username == userName, cancellationToken);
                if (foundedUser is not null)
                {
                    ViewModel.Id = foundedUser.Id;
                    ViewModel.Username = foundedUser.Username;
                    ViewModel.Gender = foundedUser.Gender;
                    ViewModel.FirstName = foundedUser.FirstName;
                    ViewModel.LastName = foundedUser.LastName;
                    ViewModel.NationalCode = foundedUser.NationalCode;
                    ViewModel.Description = foundedUser.Description;
                    if (ViewData["CultureName"].ToString() == "fa-IR")
                    {
                        ViewModel.PersianBirthDate = foundedUser.BirthDate?.ToPersianDate();
                    }
                    else
                    {
                        ViewModel.EnglishBirthDate = foundedUser.BirthDate;
                    }
                }
            }
        }

        /// <summary>
        /// ثبت اطلاعات ویرایش شده توسط کاربر در دیتابیس
        /// </summary>
        /// <returns></returns>
        public 
            async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync
            (System.Threading.CancellationToken cancellationToken)
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            try
            {
                var currentCultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

                if (DatabaseContext is not null)
                {
                    // **************************************************
                    var foundedUser = await DatabaseContext
                        .Users
                        .FirstOrDefaultAsync(user => user.Id == ViewModel.Id, cancellationToken);
                    // **************************************************

                    // **************************************************
                    string? fixedUsername = Infrastructure.Utility
                        .RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Username);
                    //if Changed UserName
                    if (foundedUser.Username != fixedUsername)
                    {
                        bool isUsernameFound = await DatabaseContext
                            .Users
                            .Where(current => current.Username == fixedUsername)
                            .AnyAsync(cancellationToken);
                        //if Exist Username in database
                        if (isUsernameFound)
                        {
                            string alreadyExistsUserName = string.Format
                                (format: Resources.Messages.Errors.AlreadyExists,arg0: Resources.DataDictionary.Username);

                            AddPageError(message: alreadyExistsUserName);
                            return Page();
                        }
                    }
                    // **************************************************

                    // **************************************************
                    if (foundedUser is not null)
                    {
                        foundedUser.Username = ViewModel.Username;
                        foundedUser.Gender = ViewModel.Gender;
                        foundedUser.FirstName = ViewModel.FirstName;
                        foundedUser.LastName = ViewModel.LastName;
                        foundedUser.NationalCode = ViewModel.NationalCode;
                        foundedUser.Description = ViewModel.Description;
                        if (currentCultureName == "fa-IR")
                        {
                            foundedUser.BirthDate = ViewModel.PersianBirthDate?.ToPersianDate();
                        }
                        else
                        {
                            foundedUser.BirthDate = ViewModel.EnglishBirthDate;
                        }


                        DatabaseContext.Users.Update(foundedUser);
                        await DatabaseContext.SaveChangesAsync(cancellationToken);

                        // **************************************************
                        var successMessage = string.Format
                            (format: Resources.Messages.Successes.SuccessUpdate, arg0: Resources.DataDictionary.User);
                        var toastSuccess = AddToastSuccess(message: successMessage);
                        return RedirectToPage("/Account/Profile", toastSuccess);
                        // **************************************************
                    }
                    // **************************************************
                }

                var toastError = AddToastError(message: Resources.Messages.Errors.UnexpectedError);
                return RedirectToPage("/Account/Profile", toastError);
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(value: exception.Message);
                
                var toastError = AddToastError(message: Resources.Messages.Errors.UnexpectedError);
                return RedirectToPage("/Account/Profile", toastError);
            }
            finally
            {
                if (DatabaseContext is not null)
                {
                    await DatabaseContext.DisposeAsync();
                    DatabaseContext = null;
                }
            }


        }
    }
}
