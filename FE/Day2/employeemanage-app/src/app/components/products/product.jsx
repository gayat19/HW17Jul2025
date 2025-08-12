'use client';

import { useEffect, useState } from 'react';
import { getProducts } from '@/app/services/product.service';
import './products.css'; // the file above


const Product = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    let mounted = true;
    getProducts()
      .then((result) => {
        const list = result?.data?.products ?? [];
        if (mounted) setProducts(list);
      })
      .catch(console.error);

    return () => {
      mounted = false; // cleanup
      console.log('component gone');
    };
  }, []);

  return (
    <div className="container mt-4">
      <div className="cards-wrap">
        {products.map((product) => (
          <div key={product.id} className="card product-card">
            <img
              className="card-img-top"
              src={product.thumbnail}
              alt={product.title}
            />
            <div className="card-body">
              <h5 className="card-title">{product.title}</h5>
              <p className="card-text">{product.description}</p>
              <button className="btn btn-primary">
                Buy for ₹{product.price}
              </button>
            </div>
          </div>
        ))}

        {products.length === 0 && (
          <div className="text-muted p-3">Loading products…</div>
        )}
      </div>
    </div>
  );
};

export default Product;
