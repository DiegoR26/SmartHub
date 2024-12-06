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

                return new Response<Association?>(association, 200, "Declara��o associada com sucesso!");

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "N�o foi possivel associar a declara��o");
            }
        }

        public async Task<Response<Association?>> DeleteAsync(DeleteAssociationRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "N�o foi possivel encontrar a associa��o");
                }

                context.Associations.Remove(association);
                await context.SaveChangesAsync();

                return new Response<Association?>(association, 200, "Associa��o exlu�da com sucesso");

            } catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "N�o foi poss�vel excluir a associa��o de declara��o");
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
                return new Response<List<Association>?>(null, 500, "N�o foi poss�vel buscar associa��es");
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
                return new Response<List<Association>?>(null, 500, "N�o foi poss�vel buscar associa��es desse cliente");
            }
        }

        public async Task<Response<Association?>> GetByIdAsync(GetAssociationByIdRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "N�o foi possivel encontrar a associa��o");
                }

                return new Response<Association?>(association);

            }catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "N�o foi possivel contrar associa��o");
            }
        }

        public async Task<Response<Association?>> UpdateAsync(UpdateAssociationRequest request)
        {
            try
            {
                var association = await context.Associations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (association is null)
                {
                    return new Response<Association?>(null, 404, "N�o foi possivel encontrar a associa��o");
                }
                
                association.Type = request.Type;
                association.Client = request.Client;
                
                context.Associations.Update(association);
                await context.SaveChangesAsync();

                return new Response<Association?>(association, 200, "Associa��o alterada com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Association?>(null, 500, "N�o foi poss�vel alterar a associa��o");
            }
        }
    }
}