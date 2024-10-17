using AutoMapper;
using BLOG.Application.Blogs.Queries.GetBlogs;
using BLOG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.Application.Common.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        { 
            CreateMap<Blog,BlogVm>().ReverseMap();
        }
    }
}
