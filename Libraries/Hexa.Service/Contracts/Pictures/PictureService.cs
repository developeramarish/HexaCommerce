using Hexa.Business.Models.Pictures;

namespace Hexa.Service.Contracts.Pictures
{
    public interface IPictureService
    {
        void DeletePicture(int id);

        PictureModel GetPictureById(int pictureId);

        int InsertPicture(PictureModel picture);
    }
}