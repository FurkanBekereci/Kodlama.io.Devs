﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.KodlamaIoUsers.Dtos
{
    public class KodlamaIoUserGetByIdDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
        public int UserId { get; set; }
    }
}
