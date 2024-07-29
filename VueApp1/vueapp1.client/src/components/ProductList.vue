<template>
    <div>
        <h1>Product List</h1>
        <table>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Description</th>
                    <th>Category Name</th>
                    <th>Image URL</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="product in products" :key="product.id">
                    <td>{{ product.name }}</td>
                    <td>{{ product.price }}</td>
                    <td>{{ product.description }}</td>
                    <td>{{ product.categoryName }}</td>
                    <td>{{ product.imageUrl }}</td>
                    <td>
                        <button @click="editProduct(product)">Edit</button>
                        <button @click="deleteProduct(product.id)">Delete</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <button @click="showAddProductForm">Add Product</button>

        <ProductForm v-if="showForm" :product="currentProduct" @save="saveProduct" @cancel="cancelForm" />
    </div>
</template>

<script>
    import ProductForm from './ProductForm.vue';
    import ProductService from '../services/ProductService';

    export default {
        data() {
            return {
                products: [],
                showForm: false,
                currentProduct: null,
            };
        },
        components: {
            ProductForm,
        },
        created() {
            this.fetchProducts();
        },
        methods: {
            fetchProducts() {
                ProductService.getAllProducts()
                    .then(response => {
                        this.products = response.data;
                    })
                    .catch(error => {
                        console.error("There was an error fetching the products!", error);
                    });
            },
            showAddProductForm() {
                this.currentProduct = null;
                this.showForm = true;
            },
            editProduct(product) {
                this.currentProduct = product;
                this.showForm = true;
            },
            deleteProduct(id) {
                ProductService.deleteProduct(id)
                    .then(() => {
                        this.fetchProducts();
                    })
                    .catch(error => {
                        console.error("There was an error deleting the product!", error);
                    });
            },
            saveProduct(product) {
                if (product.id) {
                    ProductService.updateProduct(product.id, product)
                        .then(() => {
                            this.fetchProducts();
                            this.showForm = false;
                        })
                        .catch(error => {
                            console.error("There was an error updating the product!", error);
                        });
                } else {
                    ProductService.createProduct(product)
                        .then(() => {
                            this.fetchProducts();
                            this.showForm = false;
                        })
                        .catch(error => {
                            console.error("There was an error creating the product!", error);
                        });
                }
            },
            cancelForm() {
                this.showForm = false;
            },
        },
    };
</script>

<style scoped>
    table {
        width: 100%;
        border-collapse: collapse;
    }

    th, td {
        border: 1px solid #ddd;
        padding: 8px;
    }

    th {
        background-color: #f2f2f2;
    }

    button {
        margin-right: 5px;
    }
</style>
