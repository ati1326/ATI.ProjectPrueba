using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Frontend.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;

namespace ATI.ProjectPrueba.Frontend.Pages.Countries
{
    public partial class CountryCreate
    {
        private Country country = new();
        public CountryForm? countryForm;
        [Inject] public IRepository repository { get; set; } = null!;
        [Inject] public SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] public NavigationManager navigationManager { get; set; } = null!;

        private async Task CreateAsync()
        {
            var responseHttp = await repository.PostAsync("/api/countries", country);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();
            var toast = sweetAlertService.Mixin(new SweetAlertOptions
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
            countryForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("/countries");
        }
    }
}