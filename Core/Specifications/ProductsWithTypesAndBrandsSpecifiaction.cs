using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifiaction : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecifiaction()
        {
            AddInclude(product => product.ProductType);
            AddInclude(product => product.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecifiaction(int id)
            : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductType);
            AddInclude(product => product.ProductBrand);
        }
    }
}
