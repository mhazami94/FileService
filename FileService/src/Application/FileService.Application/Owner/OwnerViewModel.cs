using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileService.Application.Owner
{
    public record class OwnerViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        [JsonIgnore]
        public bool LoginSucceeded { get; set; }
    }
}
