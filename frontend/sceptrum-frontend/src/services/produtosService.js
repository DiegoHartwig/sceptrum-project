import consumoApi from "../composables/consumoApi";

export default function produtosService(){
    const {
        metodoGet,
        metodoGetById,
        metodoPost,
        metodoUpdate,
        metodoDelete
    } = consumoApi('/api/Produtos')

    return {
        metodoGet, 
        metodoGetById,
        metodoPost, 
        metodoUpdate,
        metodoDelete
    }
}