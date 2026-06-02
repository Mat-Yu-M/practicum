using Api.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;

namespace Api.Repositories.Loans;

public sealed class LoanRepository(AppDbContext context) : ILoanRepository
{
    public async Task<LoanDto> AddAsync(AddLoanDto dto)
    {
        var entity = new LoanEntity
        {
            Id = dto.Id,
            UserId = dto.UserId,
                        Name = dto.Name, 

        };
    }
}