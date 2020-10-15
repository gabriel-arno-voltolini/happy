using FluentValidation.Results;

namespace Happy.Domain.Entities.BaseEntity
{
    internal interface IBaseEntity
    {
        void Delete();

        void Update();

        void SetId(int id);

        ValidationResult Validade();
    }
}
