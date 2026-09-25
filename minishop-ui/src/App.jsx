import { useEffect, useState } from "react";
import "./App.css";

import ProductCard from "./components/ProductCard";

import {
  getProducts,
  createOrder
} from "./services/api";

function App() {

  const [products, setProducts] = useState([]);

  const [message, setMessage] = useState("");

  const [loading, setLoading] = useState(false);

  const loadProducts = async () => {

    try {

      const data = await getProducts();

      setProducts(data);

    } catch (error) {

      setMessage(error.message);

    }

  };

  useEffect(() => {

    loadProducts();

  }, []);

  const handleOrder = async (product) => {

    const quantityText = window.prompt(
      `How many ${product.name} do you want?`,
      "1"
    );

    if (!quantityText)
      return;

    const quantity = Number(quantityText);

    if (
      Number.isNaN(quantity) ||
      quantity <= 0
    ) {

      setMessage(
        "Please enter a valid quantity."
      );

      return;
    }

    try {

      setLoading(true);

      setMessage("");

      const order = await createOrder(
        product.id,
        quantity
      );

      setMessage(
        `Order #${order.id} created successfully. Total: ${order.totalPrice} AZN`
      );

      await loadProducts();

    } catch (error) {

      setMessage(
        `Error: ${error.message}`
      );

    } finally {

      setLoading(false);

    }

  };

  return (
    <div className="app">

      <header>
        <h1>MiniShop</h1>

        <p>
          Microservices Demo
        </p>
      </header>

      {message && (
        <div className="message">
          {message}
        </div>
      )}

      {loading && (
        <p>
          Creating order...
        </p>
      )}

      <div className="product-grid">

        {products.map(product => (

          <ProductCard
            key={product.id}
            product={product}
            onOrder={handleOrder}
          />

        ))}

      </div>

    </div>
  );
}

export default App;