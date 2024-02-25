using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        //business rules

        //mapping -->automapper
        Brand brand = new()
        {
            Name = createBrandRequest.Name,
            CreatedDate = DateTime.Now
        };

        _brandDal.Add(brand);

        //mapping
        CreatedBrandResponse createdBrandResponse = new()
        {
            Id = 4,
            Name = brand.Name,
            CreatedDate = brand.CreatedDate
        };

        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDal.GetAll();

        List<GetAllBrandResponse> getAllBrandResponses = new();

        foreach (var brand in brands)
        {
            getAllBrandResponses.Add(new GetAllBrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
                CreatedDate = brand.CreatedDate,
            });
        }

        return getAllBrandResponses;
    }
}
