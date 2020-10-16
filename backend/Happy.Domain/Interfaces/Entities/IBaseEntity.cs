using FluentValidation.Results;

namespace Happy.Domain.Entities
{
    internal interface IBaseEntity
    {
        void Delete();

        void Update();

        void SetId(int id);

        ValidationResult Validade();
    }
}