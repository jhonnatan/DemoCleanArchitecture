using System;

namespace DemoCleanArchitecture.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
