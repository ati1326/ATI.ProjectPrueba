using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Frontend.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace ATI.ProjectPrueba.Frontend.Pages.Countries
{
    public partial class CountryEdit
    {
        private Country? country;
        public CountryForm? countryForm;

        [Inject] public IRepository repository { get; set; } = null!;
        [Inject] public SweetAlertService sweetAlertService { get; set; } = null!;
        [Inject] public NavigationManager navigationManager { get; set; } = null!;

        [EditorRequired, Parameter] public int ID { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await repository.GetAsync<Country>($"/api/countries/{ID}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    navigationManager.NavigateTo("/countries");
                }
                else
                {
                    var errorMessage = await responseHttp.GetErrorMessageAsync();
                    await sweetAlertService.FireAsync("Error", errorMessage, SweetAlertIcon.Error);
                }
            }
            else
            {
                country = responseHttp.Response;
            }
        }

        private async Task EditAsync()
        {
            var responseHttp = await repository.PutAsync("/api/countries", country);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios Guardados  con Exito");
        }

        private void Return()
        {
            countryForm!.FormPostedSuccessfully = true;
            navigationManager.NavigateTo("/countries");
        }
    }
}
