using AutoMapper;
using Hexa.Business.Models.Pictures;
using Hexa.Core.Data;
using Hexa.Core.Domain.Pictures;
using Hexa.Service.Contracts.Pictures;
using System;
using System.Threading.Tasks;

namespace Hexa.Service.Services.Pictures
{
    public class PictureService : IPictureService
    {
        private readonly IHexaRepository<Picture> _pictureRepository;
        private readonly IMapper _mapper;

        public PictureService(IHexaRepository<Picture> pictureRepository,
            IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }

        public async Task DeletePicture(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("picture");

            await _pictureRepository.Delete(_mapper.Map<Picture>(await GetPictureById(id)));
        }

        public async Task<PictureModel> GetPictureById(int pictureId)
        {
            if (pictureId == 0)
                return null;

            return _mapper.Map<PictureModel>(await _pictureRepository.GetById(pictureId));
        }

        public async Task<int> InsertPicture(PictureModel picture)
        {
            if (picture == null)
                throw new ArgumentNullException("picture");

            var newPicture = _mapper.Map<Picture>(picture);
            await _pictureRepository.Insert(newPicture);

            if (newPicture == null)
            {
                return 0;
            }

            return await Task.FromResult(newPicture.Id);
        }
    }
}