<template>
    <div>
        <h2>{{ product.id ? 'Edit' : 'Add' }} Product</h2>
        <form @submit.prevent="submitForm">
            <div>
                <label>Name:</label>
                <input type="text" v-model="product.name" required />
            </div>
            <div>
                <label>Price:</label>
                <input type="number" v-model="product.price" required />
            </div>
            <div>
                <label>Description:</label>
                <input type="text" v-model="product.description" required />
            </div>
            <div>
                <label>Category Name:</label>
                <input type="text" v-model="product.categoryName" required />
            </div>
            <div>
                <label>Image URL:</label>
                <input type="text" v-model="product.imageUrl" required />
            </div>
            <div>
                <button type="submit">Save</button>
                <button type="button" @click="$emit('cancel')">Cancel</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        props: {
            product: {
                type: Object,
                default: () => ({ name: '', price: 0, description: '', categoryName: '', imageUrl: '' })
            }
        },
        data() {
            return {
                product: this.product
            };
        },
        methods: {
            submitForm() {
                this.$emit('save', this.product);
            }
        }
    };
</script>

<style scoped>
    form div {
        margin-bottom: 10px;
    }

    button {
        margin-right: 5px;
    }
</style>
