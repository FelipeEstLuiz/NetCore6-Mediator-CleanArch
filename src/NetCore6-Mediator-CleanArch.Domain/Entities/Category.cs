﻿using NetCore6_Mediator_CleanArch.Domain.Validation;

namespace NetCore6_Mediator_CleanArch.Domain.Entities;

public sealed class Category : Entity
{
    public ICollection<Product>? Products { get; set; }

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");

        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(name is null, "Invalid name. Name is required");
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name?.Length < 3, "Invalid name, too short, minimum 3 characters");

        Name = name;
    }
}
