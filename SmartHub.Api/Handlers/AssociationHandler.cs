using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Data.Mappings;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Associations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Handlers
{
    public class AssociationHandler(AppDbContext context) : IAssociationHandler
    {
        public async Task<Response<Association?>> CreateAsync(CreateAssociationRequest request)
        {
            try
            {
                var association = new Association
                {
                    Client = request.Client,
                    Type = request.Type,
                };

                await context.Associations.AddAsync(association);
                await context.SaveChangesAsync();

                return new Response<Association?>(association, 200, "Declaração associada com sucesso!");

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "Não foi possivel associar a declaração");
            }
        }

        public async Task<Response<Association?>> DeleteAsync(DeleteAssociationRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "Não foi possivel encontrar a associação");
                }

                context.Associations.Remove(association);
                await context.SaveChangesAsync();

                return new Response<Association?>(association, 200, "Associação exluída com sucesso");

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "Não foi possível excluir a associação de declaração");
            }
        }

        public async Task<Response<List<Association>?>> GetAllAsync(GetAllAssociationsRequest request)
        {
            try
            {
                var association = await context.Associations
                                                .Include(x => x.Client)
                                                .Where(x => x.Client.UserId == request.UserId)
                                                .AsNoTracking()
                                                .ToListAsync();

                return new Response<List<Association>?>(association);

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Association>?>(null, 500, "Não foi possível buscar associações");
            }
        }

        public async Task<Response<List<Association>?>> GetByClientAsync(GetAssociationsByClientRequest request)
        {
            try
            {
                var association = await context.Associations
                                                .Include(x => x.Client)
                                                .Where(x => x.Client.UserId == request.UserId && x.Client == request.Client)
                                                .AsNoTracking()
                                                .ToListAsync();

                return new Response<List<Association>?>(association);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Association>?>(null, 500, "Não foi possível buscar associações desse cliente");
            }
        }

        public async Task<Response<Association?>> GetByIdAsync(GetAssociationByIdRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "Não foi possivel encontrar a associação");
                }

                return new Response<Association?>(association);

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "Não foi possivel contrar associação");
            }
        }

        public async Task<Response<Association?>> UpdateAsync(UpdateAssociationRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "Não foi possivel encontrar a associação");
                }
                
                association.Type = request.Type;
                association.Client = request.Client;
                
                context.Associations.Update(association);
                await context.SaveChangesAsync();

                return new Response<Association?>(association, 200, "Associação alterada com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "Não foi possível alterar a associação");
            }
        }
    }
}