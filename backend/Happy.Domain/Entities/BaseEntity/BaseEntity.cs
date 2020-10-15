using FluentValidation;
using FluentValidation.Results;
using System;

namespace Happy.Domain.Entities.BaseEntity
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected readonly IValidator _validator;

        public int Id { get; protected set; }
        public bool Deleted { get; protected set; }
        public DateTime EntryTime { get; protected set; }
        public DateTime? LastUpdate { get; protected set; }
        public DateTime? Exclusion { get; protected set; }

        protected BaseEntity(IValidator validator)
        {
            EntryTime = DateTime.Now;
            _validator = validator;
        }

        public void Delete()
        {
            Deleted = true;
            Exclusion = DateTime.Now;
        }

        public void Update()
        {
            LastUpdate = DateTime.Now;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public ValidationResult Validade()
        {
            return _validator.Validate(this);
        }
    }
}
