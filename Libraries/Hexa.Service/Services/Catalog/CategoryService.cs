using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using Hexa.Service.Contracts.Pictures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hexa.Service.Services.Catalog
{
    public class CategoryService : ICategoryService
    {
        #region Fields

        private readonly IHexaRepository<Category> _categoryRepository;
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public CategoryService(IHexaRepository<Category> categoryRepository,
            IPictureService pictureService,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _pictureService = pictureService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task DeleteCategory(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("category");

            var category = await GetCategoryById(id);
            category.Deleted = true;
            await UpdateCategory(category);
        }

        public async Task<CategoryModel> GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            var result = _mapper.Map<CategoryModel>(await _categoryRepository.GetById(categoryId));
            if (result != null && result.PictureId > 0)
            {
                result.Picture = await _pictureService.GetPictureById(result.PictureId);
            }

            return result;
        }

        public async Task InsertCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            await _categoryRepository.Insert(_mapper.Map<Category>(category));
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            await _categoryRepository.Update(_mapper.Map<Category>(category));
        }

        public async Task<List<CategoryModel>> GetAllCategories(string name)
        {
            var query = _categoryRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return _mapper.Map<List<CategoryModel>>(await query.OrderBy(a => a.DisplayOrder).ToListAsync());
        }

        #endregion
    }
}
