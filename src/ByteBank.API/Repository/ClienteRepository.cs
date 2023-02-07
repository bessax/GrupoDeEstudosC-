// <copyright file="ClienteRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Base;
using ByteBank.API.Data;
using ByteBank.API.Interface;
using ByteBank.API.Models;

namespace ByteBank.API.Repository;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    private readonly ByteBankContext context;

    public ClienteRepository(ByteBankContext context)
        : base(context)
    {
        this.context = context;
    }
}