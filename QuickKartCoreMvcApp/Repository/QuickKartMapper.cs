using AutoMapper;
using QuickKartDataAccessLayer.Models;

namespace QuickKartCoreMvcApp.Repository
{
    public class QuickKartMapper:Profile
    {
        public QuickKartMapper()
        {
            //Models.Products is model for presentation layer in QuickKartCoreMvcApp
            //first parameter is source and second parameter is destination
            CreateMap<Products, Models.Products>();
            CreateMap<Models.Products,Products>();
        }
    }
}
