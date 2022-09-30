using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Models;
using KodlamaIoDevs.Application.Features.KodlamaIoUsers.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using KodlamaIoDevs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Queries.GetListKodlamaIoUser
{
    public class GetListKodlamaIoUserQuery : IRequest<KodlamaIoUserListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListKodlamaIoUserQueryHandler : IRequestHandler<GetListKodlamaIoUserQuery, KodlamaIoUserListModel>
        {
            private readonly IKodlamaIoUserRepository _kodlamaIoUserRepository;
            private readonly IMapper _mapper;
            private readonly KodlamaIoUserBusinessRules _kodlamaIoUserBusinessRules;

            public GetListKodlamaIoUserQueryHandler(IKodlamaIoUserRepository kodlamaIoUserRepository, IMapper mapper, KodlamaIoUserBusinessRules kodlamaIoUserBusinessRules)
            {
                _kodlamaIoUserRepository = kodlamaIoUserRepository;
                _mapper = mapper;
                _kodlamaIoUserBusinessRules = kodlamaIoUserBusinessRules;
            }

            public async Task<KodlamaIoUserListModel> Handle(GetListKodlamaIoUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<KodlamaIoUser> kodlamaIoUserList = await _kodlamaIoUserRepository.GetListAsync(
                                                                    index: request.PageRequest.Page,
                                                                    size: request.PageRequest.PageSize,
                                                                    include: i => i.Include(i => i.User)
                                                                    );
                
                KodlamaIoUserListModel kodlamaIoUserListModel = _mapper.Map<KodlamaIoUserListModel>(kodlamaIoUserList);

                return kodlamaIoUserListModel;

                                                         
            }
        }
    }
}
