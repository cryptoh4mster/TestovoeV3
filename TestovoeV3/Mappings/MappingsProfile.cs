using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestovoeV3.ViewModels;
using TestovoeV3BLL.DTO;
using TestovoeV3DAL.Entities;
using TestovoeV3DAL.Helpers;

namespace TestovoeV3.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateFileViewModel, CreateFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<CreateFileDTO, CreateFileViewModel>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<CreateFileDTO, File>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Data, opt => opt.ConvertUsing(new FileToByteResolver(), src=>src.File));
            CreateMap<File, CreateFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.ConvertUsing(new ByteToFileResolver(), src=>src.Data));
            /*CreateMap<CreateFileDTO, File>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Data, opt => opt.ConvertUsing(new ImgToByteResolver()));
            CreateMap<File, CreateFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Image, opt => opt.ConvertUsing(new ByteToImgResolver()));*/
            CreateMap<IndexFileViewModel, IndexFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.Image));
            CreateMap<IndexFileDTO, IndexFileViewModel>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.File));
            CreateMap<IndexFileDTO, File>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Data, opt => opt.ConvertUsing(new FileToByteResolver(), src=>src.File));
            CreateMap<File, IndexFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.ConvertUsing(new ByteToFileResolver(), src=>src.Data));
            /*CreateMap<File, IndexFileDTO>()
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Image, opt => opt.ConvertUsing(new ByteToImgResolver()));*/
        }
    }
}