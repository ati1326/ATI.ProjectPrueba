using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Frontend.Pages.Countries;
using ATI.ProjectPrueba.Frontend.Repositories;
using ATI.ProjectPrueba.Frontend.Shared;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace ATI.ProjectPrueba.Frontend.Pages.Categories
{
    public  partial class CategoryCreate
    {

        private Category category = new();

        public FormWithName<Category>? categoryFrom;
        [Inject] public IRepository Repository { get; set; } = null!;
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync("/api/categories", category);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con Exito");
        }

        private void Return()
        {
            categoryFrom!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/categories");
        }
    }

}
