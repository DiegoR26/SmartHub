using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Data.Mappings;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Clients;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Handlers
{
    public class ClientHandler(AppDbContext context) : IClientHandler
    {
        public async Task<Response<Client?>> CreateAsync(CreateClientRequest request)
        {
            try
            {
                var client = new Client
                {
                    Cod = request.Cod,
                    Name = request.Name,
                    Taxation = request.Taxation,
                    CNPJ = request.CNPJ,
                    IM = request.IM,
                    IE = request.IE,
                    City = request.City,
                    Country = request.Country,
                    DecPassword = request.DecPassword,
                    Observations = request.Observations,
                    SefazAccess = request.SefazAccess,
                    Email = request.Email,
                    UserId = request.UserId
                };

                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();

                return new Response<Client?>(client, 201, "Cliente criado com sucesso!");

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Client?>(null, 500, "Não foi possível criar um cliente");
            } 
        }

        public async Task<Response<Client?>> DeleteAsync(DeleteClientRequest request)
        {
            try
            {
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (client is null)
                {
                    return new Response<Client?>(null, 404, "Não foi possivel encontrar o cliente");
                }

                context.Clients.Remove(client);
                await context.SaveChangesAsync();

                return new Response<Client?>(client, 200, "Cliente excluido com sucesso!");


            } catch(Exception e)
            {
                Console.WriteLine(e);
                return new Response<Client?>(null, 500, "Não foi possível excluir o cliente");
            }
        }

        public async Task<Response<List<Client>?>> GetAllAsync(GetAllClientsRequest request)
        {
            try
            {
                var query = context.Clients.AsNoTracking().Where(x => x.UserId == request.UserId).OrderBy(x => x.Name);

                var clients = await query.ToListAsync();

                return new Response<List<Client>?>(clients);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Client>?>(null, 500, "Não foi possível buscar clientes");
            }
        }

        public async Task<Response<Client?>> GetByIdAsync(GetClientByIdRequest request)
        {
            try
            {
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (client is null)
                {
                    return new Response<Client?>(null, 404, "Não foi possivel encontrar o cliente");
                }

                return new Response<Client?>(client, 200, "Cliente encontrado com sucesso!");

            } catch(Exception e)
            {
                Console.WriteLine(e);
                return new Response<Client?>(null, 500, "Não foi possível encontrar o cliente");
            }
        }

        public async Task<Response<Client?>> UpdateAsync(UpdateClientRequest request)
        {
            try
            {
                var client = await context.Clients.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (client is null)
                {
                    return new Response<Client?>(null, 404, "Não foi possivel encontrar o cliente");
                }

                client.Cod = request.Cod;
                client.Name = request.Name;
                client.Taxation = request.Taxation;
                client.CNPJ = request.CNPJ;
                client.IM = request.IM;
                client.IE = request.IE;
                client.City = request.City;
                client.Country = request.Country;
                client.DecPassword = request.DecPassword;
                client.Observations = request.Observations;
                client.SefazAccess = request.SefazAccess;
                client.Email = request.Email;
                client.IsActive = request.IsActive;


                context.Clients.Update(client);
                await context.SaveChangesAsync();

                return new Response<Client?>(client, 200, "Cliente alterado com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Client?>(null, 500, "Não foi possível alterar o cliente");
            }
        }
    }
}