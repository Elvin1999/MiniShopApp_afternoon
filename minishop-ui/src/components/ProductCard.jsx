export default function ProductCard({
  product,
  onOrder
}) {
  return (
    <div className="product-card">

      <h2>{product.name}</h2>

      <p className="price">
        {product.price} AZN
      </p>

      <p>
        Stock: {product.stock}
      </p>

      <button
        disabled={product.stock === 0}
        onClick={() => onOrder(product)}
      >
        Order
      </button>

    </div>
  );
}