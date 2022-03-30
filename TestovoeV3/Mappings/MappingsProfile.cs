using AutoMapper;
using TestovoeV3.ViewModels;
using TestovoeV3BLL.DTO;
using TestovoeV3DAL.Entities;
using TestovoeV3BLL.Helpers;


namespace TestovoeV3.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateFileViewModel, CreateFileDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<CreateFileDTO, CreateFileViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<CreateFileDTO, File>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Data, opt => opt.ConvertUsing(new FileToByteResolver(), src=>src.File));
            CreateMap<File, CreateFileDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.ConvertUsing(new ByteToFileResolver(), src=>src.Data));
            CreateMap<IndexFileViewModel, IndexFileDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<IndexFileDTO, IndexFileViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File));
            CreateMap<IndexFileDTO, File>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.Data, opt => opt.ConvertUsing(new FileToByteResolver(), src=>src.File));
            CreateMap<File, IndexFileDTO>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                    .ForMember(dest => dest.File, opt => opt.ConvertUsing(new ByteToFileResolver(), src=>src.Data));
        }
    }
}