using AutoMapper;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;

namespace PharmaAPICreation.Mapper
{
    public class MappingData : Profile
    {

        public MappingData()
        {
            CreateMap<User, LoginResponseDTO>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            //Medicine by Raju------------------------------------>
            CreateMap<Medicine, MedicineReadDTO>().ReverseMap();
            CreateMap<MedicineCreateDTO, Medicine>().ReverseMap();
            CreateMap<MedicineUpdateDTO, Medicine>().ReverseMap();
            //----------------------------------------------------x

            //------------------------------------------------------------------------------------------------------------------------

            CreateMap<Purchase, PurchaseReadDTO>()
           .ForMember(x => x.SupplierName, x => x.MapFrom(x => x.Supplier.Name))
           .ForMember(x => x.BranchName, x => x.MapFrom(x => x.Branch.BranchName));

            CreateMap<PurchaseCreateDTO, Purchase>()
                .ForMember(x => x.CreatedAt, x => x.MapFrom(x => DateTime.Now));

            CreateMap<PurchaseUpdateDTO, Purchase>()
                .ForMember(x => x.UpdatedAt, x => x.MapFrom(x => DateTime.Now));
//----------------------------------------------------------------------------------------------------------------------

            CreateMap<PurchaseItemCreateDTO, PurchaseItem>();
            CreateMap<PurchaseItemUpdateDTO, PurchaseItem>();

            CreateMap<PurchaseItem, PurchaseItemReadDTO>()
                .ForMember(dest => dest.MedicineName, opt => opt.MapFrom(src => src.Medicine.Name))
                .ForMember(dest => dest.PurchaseInvoiceNo, opt => opt.MapFrom(src => src.Purchase.InvoiceNo));

 //---------------------------------------------------------------------------------------------------------------------



            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Medicine, MedicineDTOs>().ReverseMap();

        }


    }



}

