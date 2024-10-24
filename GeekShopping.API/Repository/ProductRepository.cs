﻿using AutoMapper;
using GeekShopping.ProductAPI.Model;
using GeekShoppingProduct.API.Data.ValueObjects;
using GeekShoppingProduct.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShoppingProduct.API.Repository;

public class ProductRepository : IProductRepository
{
    private readonly MySqlContext _context;
    private IMapper _mapper;
    public ProductRepository(MySqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductVO>> FindAll()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductVO>>(products);
    }

    public async Task<ProductVO> FindById(long id)
    {
        Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Create(ProductVO vo)
    {
        // Entra vo e retorna vo, só é persistido como objeto
        Product product = _mapper.Map<Product>(vo);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Update(ProductVO vo)
    {
        Product product = _mapper.Map<Product>(vo);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}
