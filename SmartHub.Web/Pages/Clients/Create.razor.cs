using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartHub.Core.Handlers;
using SmartHub.Core.Requests.Clients;

namespace SmartHub.Web.Pages.Clients
{
    public partial class CreateClientPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public CreateClientRequest Request { get; set; } = new CreateClientRequest();

        #endregion

        #region Services

        [Inject]
        public IClientHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(Request);

                if (result.IsSucess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/clientes");
                } else
                {
                    Snackbar.Add(result.Message, Severity.Error);
                }

            } catch (Exception e)
            {
                Snackbar.Add(e.Message, Severity.Error);

            } finally
            {
                IsBusy = false;
            }

        }

        #endregion

    }
}
