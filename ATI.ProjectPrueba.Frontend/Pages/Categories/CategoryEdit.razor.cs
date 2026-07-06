using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Frontend.Repositories;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace ATI.ProjectPrueba.Frontend.Pages.Categories
{
    public partial class CategoryEdit
    {
        private Category? category;
        public CategoryFrom? categoryFrom;

        [Inject] public IRepository Repository { get; set; } = null!;
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] public NavigationManager NavigationManager  { get; set; } = null!;

        [EditorRequired, Parameter] public int ID { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Category>($"/api/categories/{ID}");
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                       NavigationManager.NavigateTo("/categories");
                }
                else
                {
                    var errorMessage = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", errorMessage, SweetAlertIcon.Error);
                }
            }
            else
            {
                category = responseHttp.Response;
            }
        }

        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync("/api/categories", category);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios Guardados  con Exito");
        }

        private void Return()
        {
            categoryFrom!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/categories");
        }
    }
}
