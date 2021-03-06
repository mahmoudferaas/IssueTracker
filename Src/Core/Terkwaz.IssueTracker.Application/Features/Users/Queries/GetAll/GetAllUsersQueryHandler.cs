﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Application.Features.Users.Comands.Dtos;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserOutput>>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserOutput>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _context.Users
                    .Include(a => a.Projects)
                    .Include(a => a.IssueAssignees)
                    .Include(a => a.IssueReporters).ToListAsync();

                var result =  _mapper.Map<List<UserOutput>>(users);

                return result;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        //public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var users = await _context.Users
        //            .Include(a => a.Projects)
        //            .Include(a => a.IssueAssignees)
        //            .Include(a => a.IssueReporters).ToListAsync();

        //        return users;
        //    }
        //    catch (System.Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}