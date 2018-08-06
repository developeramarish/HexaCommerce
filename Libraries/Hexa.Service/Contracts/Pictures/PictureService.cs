using Hexa.Business.Models.Pictures;
using System.Threading.Tasks;

namespace Hexa.Service.Contracts.Pictures
{
    public interface IPictureService
    {
        Task DeletePicture(int id);

        Task<PictureModel> GetPictureById(int pictureId);

        Task<int> InsertPicture(PictureModel picture);
    }
}