using Microsoft.EntityFrameworkCore;
using SmartHub.Api.Data.Mappings;
using SmartHub.Core.Common;
using SmartHub.Core.Handlers;
using SmartHub.Core.Models;
using SmartHub.Core.Requests.Declarations;
using SmartHub.Core.Responses;

namespace SmartHub.Api.Handlers
{
    public class DeclarationHandler(AppDbContext context) : IDeclarationHandler
    {
        public async Task<Response<Declaration?>> CreateAsync(CreateDeclarationRequest request)
        {
            try
            {
                var exists = await context.Declarations.AnyAsync(d => d.Client == request.Client && d.Competence == request.Competence);

                if (exists)
                {
                    return new Response<Declaration?>(null, 409, "Declara��o j� existe para esta compet�ncia.");
                }

                var declaration = new Declaration
                {
                    Client = request.Client,
                    Competence = request.Competence,
                    Type = request.Type
                };

                await context.Declarations.AddAsync(declaration);
                await context.SaveChangesAsync();

                return new Response<Declaration?>(declaration, 201, "Declara��o criada com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Declaration?>(null, 500, "N�o foi poss�vel criar a declara��o");
            }
        }

        public async Task<Response<Declaration?>> DeleteAsync(DeleteDeclarationRequest request)
        {
            try
            {
                var declaration = await context.Declarations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (declaration is null)
                {
                    return new Response<Declaration?>(null, 404, "N�o foi possivel encontrar a declara��o");
                }

                context.Declarations.Remove(declaration);
                await context.SaveChangesAsync();

                return new Response<Declaration?>(declaration, 200, "Declara��o exclu�da com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Declaration?>(null, 500, "N�o foi poss�vel excluir a declara��o");
            }
        }

        public async Task<Response<List<Declaration>?>> GetAllAsync(GetAllDeclarationsRequest request)
        {
            try
            {
                var declarations = await context.Declarations
                    .Include(x => x.Client)
                    .Where(x => x.Client.UserId == request.UserId)
                    .AsNoTracking()
                    .ToListAsync();

                return new Response<List<Declaration>?>(declarations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Declaration>?>(null, 500, "N�o foi poss�vel buscar declara��es");
            }
        }

        public async Task<Response<List<Declaration>?>> GetByCompetenceAsync(GetDeclarationsByCompetenceRequest request)
        {
            try
            {
                request.StartDate ??= DateTime.Now.GetFirstDay();
                request.EndDate ??= DateTime.Now.GetLastDay();

                var declarations = await context.Declarations
                    .Include(x => x.Client)
                    .Where(x => x.Competence >= request.StartDate && x.Competence <= request.EndDate && x.Client.UserId == request.UserId)
                    .AsNoTracking()
                    .OrderBy(x => x.Client.Name)
                    .ToListAsync();

                return new Response<List<Declaration>?>(declarations);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<List<Declaration>?>(null, 500, "N�o foi poss�vel buscar declara��es");
            }
        }

        public async Task<Response<Declaration?>> GetByIdAsync(GetDeclarationByIdRequest request)
        {
            try
            {
                var declaration = await context.Declarations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (declaration is null)
                {
                    return new Response<Declaration?>(null, 404, "N�o foi possivel encontrar a declara��o");
                }

                return new Response<Declaration?>(declaration);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Declaration?>(null, 500, "N�o foi poss�vel encontrar a declara��o");
            }
        }

        public async Task<Response<Declaration?>> UpdateAsync(UpdateDeclarationRequest request)
        {
            try
            {
                var declaration = await context.Declarations.FirstOrDefaultAsync(x => x.Id == request.Id && x.Client.UserId == request.UserId);

                if (declaration is null)
                {
                    return new Response<Declaration?>(null, 404, "N�o foi possivel encontrar a declara��o");
                }

                declaration.Type = request.Type;
                declaration.Competence = request.Competence;
                declaration.IsActive = request.IsActive;
                declaration.Situation = request.Situation;

                context.Declarations.Update(declaration);
                await context.SaveChangesAsync();

                return new Response<Declaration?>(declaration, 200, "Cliente alterado com sucesso");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Response<Declaration?>(null, 500, "N�o foi poss�vel alterar a declara��o");
            }
        }
    }
}