import axios from 'axios';

const API_URL = 'http://localhost:7088/api/products'; // Remplacez par l'URL réelle de votre API

class ProductService {
    getAllProducts() {
        return axios.get(API_URL);
    }

    getProductById(id) {
        return axios.get(`${API_URL}/${id}`);
    }

    createProduct(product) {
        return axios.post(API_URL, product);
    }

    updateProduct(id, product) {
        return axios.put(`${API_URL}/${id}`, product);
    }

    deleteProduct(id) {
        return axios.delete(`${API_URL}/${id}`);
    }
}

export default new ProductService();
