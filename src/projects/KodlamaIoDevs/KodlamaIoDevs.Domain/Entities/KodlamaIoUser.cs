﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Domain.Entities
{
    public class KodlamaIoUser : Entity
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }
        public virtual User User{ get; set; }

        public KodlamaIoUser()
        {

        }

        public KodlamaIoUser(int id, int userId, string githubUrl) : this()
        {
            this.Id = id;
            this.UserId = userId;
            this.GithubUrl = githubUrl;
        }
    }
}