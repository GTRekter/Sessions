using System;
using GettingStartedWithASPNETCore.Interfaces;

public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
{
    Guid _guid;
    public Operation() : this(Guid.NewGuid())
    {
    }

    public Operation(Guid guid)
    {
        _guid = guid;
    }

    public Guid OperationId => _guid;
}