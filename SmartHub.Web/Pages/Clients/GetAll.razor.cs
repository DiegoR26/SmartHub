using Microsoft.AspNetCore.Components;
using MudBlazor;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using System.Diagnostics.Tracing;

namespace SmartHub.Web.Pages.Clients
{
    public partial class GetAllClientsPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;

        public List<Client> Clients { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public IClientHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {

                var request = new GetAllClientsRequest();

                var result = await Handler.GetAllAsync(request);
                
                if (result.IsSucess)
                {
                    Clients = result.Data ?? [];
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

        #region Methods

        public async void OnDeleteButtonClickedAsync(int id, string client)
        {
            var result = await Dialog.ShowMessageBox("Atenção!", $"{client} irá embora para nunca mais voltar. Deseja continuar?", yesText: "Excluir", cancelText: "Cancelar");

            if (result is true)
            {
                await OnDeleteAsync(id, client);
            }

            StateHasChanged();
        }

        public async Task OnDeleteAsync(int id, string client)
        {
            try
            {
                var request = new DeleteClientRequest
                {
                    Id = id
                };

                await Handler.DeleteAsync(request);

                Clients.RemoveAll(x => x.Id == id);

                Snackbar.Add($"{client} excluído!", Severity.Info);

            } catch (Exception e)
            {
                Snackbar.Add(e.Message, Severity.Error);
            }
        }

        #endregion
    }
}
