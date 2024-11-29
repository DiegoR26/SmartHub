﻿using SmartHub.Core.Models;
using SmartHub.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartHub.Core.Requests.Declarations
{
    public class CreateDeclarationRequest : Request
    {
        [Required(ErrorMessage = "Tipo de Declaração Inválida")]
        public required DeclarationType Type { get; set; }

        [Required(ErrorMessage = "Competência Inválida")]
        public required DateTime Competence { get; set; }

        [Required(ErrorMessage = "Cliente Inválido")]
        public Client Client { get; set; }

    }
}