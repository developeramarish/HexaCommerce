using AutoMapper;
using Hexa.Business.Models.Catalog;
using Hexa.Core.Data;
using Hexa.Core.Domain.Catalog;
using Hexa.Service.Contracts.Catalog;
using Hexa.Service.Contracts.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteCategory(int id)
        {
            if (id == 0)
                throw new ArgumentNullException("category");

            var category = GetCategoryById(id);
            category.Deleted = true;
            UpdateCategory(category);
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            var result = _mapper.Map<CategoryModel>(_categoryRepository.GetById(categoryId));
            if (result != null && result.PictureId > 0)
            {
                result.Picture = _pictureService.GetPictureById(result.PictureId);
            }

            return result;
        }

        public void InsertCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Insert(_mapper.Map<Category>(category));
        }

        public void UpdateCategory(CategoryModel category)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            _categoryRepository.Update(_mapper.Map<Category>(category));
        }

        public List<CategoryModel> GetAllCategories(string name)
        {
            var query = _categoryRepository.Table;
            query = query.Where(c => c.Active);
            query = query.Where(c => !c.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(a => a.Name.Contains(name));

            return _mapper.Map<List<CategoryModel>>(query.OrderBy(a => a.DisplayOrder).ToList());
        }

        #endregion
    }
}
