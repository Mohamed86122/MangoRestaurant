<template>
    <div id="app">
        <ProductList />
    </div>
</template>

<script>
    import ProductList from './components/ProductList.vue';

    export default {
        name: 'App',
        components: {
            ProductList,
        },
    };
</script>
