using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Data.Mappings;
using SmartHub.Core.Common;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Slips;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Handlers
{
    public class SlipHandler(AppDbContext context) : ISlipHandler
    {
        public async Task<Response<Slip?>> CreateAsync(CreateSlipRequest request)
        {
            try
            {
                var exists = await context.Slips.AnyAsync(d => d.Client == request.Client && d.Competence == request.Competence);

                if (exists)
                {
                    return new Response<Slip?>(null, 409, "guia já existe para esta competência.");
                }

                var slip = new Slip
                {
                    Client = request.Client,
                    Competence = request.Competence,
                    Type = request.Type
                };

                await context.Slips.AddAsync(slip);
                await context.SaveChangesAsync();

                return new Response<Slip?>(slip, 201, "Guia criada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Slip?>(null, 500, "Não foi possível criar a guia");
            }
        }

        public async Task<Response<Slip?>> DeleteAsync(DeleteSlipRequest request)
        {
            try
            {
                var slip = await context.Slips.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (slip is null)
                {
                    return new Response<Slip?>(null, 404, "Não foi possivel encontrar a guia");
                }

                context.Slips.Remove(slip);
                await context.SaveChangesAsync();

                return new Response<Slip?>(slip, 200, "Guia excluída com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Slip?>(null, 500, "Não foi possível excluir a guia");
            }
        }

        public async Task<Response<List<Slip>?>> GetAllAsync(GetAllSlipsRequest request)
        {
            try
            {
                var slips = await context.Slips
                    .Include(x => x.Client)
                    .Where(x => x.Client.UserId == request.UserId)
                    .AsNoTracking()
                    .ToListAsync();

                return new Response<List<Slip>?>(slips);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Slip>?>(null, 500, "Não foi possível buscar guias");
            }
        }

        public async Task<Response<List<Slip>?>> GetByCompetenceAsync(GetSlipsByCompetenceRequest request)
        {
            try
            {
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();

                var slips = await context.Slips
                    .Include(x => x.Client)
                    .Where(x => x.Competence >= request.StartDate && x.Competence <= request.EndDate && x.Client.UserId == request.UserId)
                    .AsNoTracking()
                    .OrderBy(x => x.Client.Name)
                    .ToListAsync();

                return new Response<List<Slip>?>(slips);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Slip>?>(null, 500, "Não foi possível buscar guias");
            }
        }

        public async Task<Response<Slip?>> GetByIdAsync(GetSlipByIdRequest request)
        {
            try
            {
                var slip = await context.Slips.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (slip is null)
                {
                    return new Response<Slip?>(null, 404, "Não foi possivel encontrar a guia");
                }

                return new Response<Slip?>(slip);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Slip?>(null, 500, "Não foi possível encontrar a guia");
            }
        }

        public async Task<Response<Slip?>> UpdateAsync(UpdateSlipRequest request)
        {
            try
            {
                var slip = await context.Slips.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (slip is null)
                {
                    return new Response<Slip?>(null, 404, "Não foi possivel encontrar a guia");
                }

                slip.Type = request.Type;
                slip.Competence = request.Competence;
                slip.IsActive = request.IsActive;
                slip.Situation = request.Situation;

                context.Slips.Update(slip);
                await context.SaveChangesAsync();

                return new Response<Slip?>(slip, 200, "Cliente alterado com sucesso");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Slip?>(null, 500, "Não foi possível alterar a guia");
            }
        }
    }
}