const API_URL = "http://localhost:7000/api";

export async function getProducts() {
  const response = await fetch(
    `${API_URL}/products`
  );

  if (!response.ok) {
    throw new Error("Could not load products");
  }

  return response.json();
}

export async function createOrder(productId, quantity) {
  const response = await fetch(
    `${API_URL}/orders`,
    {
      method: "POST",

      headers: {
        "Content-Type": "application/json"
      },

      body: JSON.stringify({
        productId,
        quantity
      })
    }
  );

  if (!response.ok) {
    const error = await response.text();

    throw new Error(error);
  }

  return response.json();
}